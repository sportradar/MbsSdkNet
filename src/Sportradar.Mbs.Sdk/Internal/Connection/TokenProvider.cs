using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sportradar.Mbs.Sdk.Exceptions;
using Sportradar.Mbs.Sdk.Internal.Config;
using Sportradar.Mbs.Sdk.Internal.Utils;

namespace Sportradar.Mbs.Sdk.Internal.Connection;

internal class TokenProvider : IDisposable
{
    private readonly ITokenProviderConfig _config;
    private readonly SemaphoreSlim _semaphore;

    private string _token;
    private long _ts;

    internal TokenProvider(ImmutableConfig config)
    {
        _config = config;
        _semaphore = new SemaphoreSlim(1);
        _token = "";
        _ts = 0;
    }

    public void Dispose()
    {
        ExcSuppress.Dispose(_semaphore);
    }

    private string? GetToken()
    {
        var result = _token;
        if (string.IsNullOrEmpty(result)) return null;

        var now = TimeUtils.NowInUtcMillis();
        return now > _ts ? null : result;
    }

    private void SetToken(string token, long ts)
    {
        _token = token;
        _ts = ts;
    }

    internal async Task<string> GetAuthTokenAsync(CancellationToken cancellationToken)
    {
        try
        {
            await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                Exception? possibleExc = null;
                string? token = null;
                for (var i = 0; i < 10 && token == null; i++)
                    try
                    {
                        token = GetToken() ?? await FetchTokenAsync(cancellationToken).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        possibleExc = e;
                    }

                if (token == null)
                {
                    var exc = possibleExc.NotNull();
                    throw exc;
                }
                else
                {
                    return token;
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }
        catch (SdkException)
        {
            throw;
        }
        catch (Exception e)
        {
            throw new AuthTokenFailureException(e);
        }
    }

    private async Task<string?> FetchTokenAsync(CancellationToken cancellationToken)
    {
        try
        {
            using HttpClient httpClient = new();
            httpClient.Timeout = _config.AuthRequestTimeout;
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", _config.AuthClientId),
                new KeyValuePair<string, string>("client_secret", _config.AuthClientSecret),
                new KeyValuePair<string, string>("audience", _config.AuthAudience)
            });

            var response = await httpClient.PostAsync(_config.AuthServer, request, cancellationToken)
                .ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var token = ProcessResponseContent(content);
                return token.NotNull();
            }

            throw new AuthTokenFailureException("Invalid response returned from auth server");
        }
        catch
        {
            await Task.Delay(_config.AuthRetryDelay, cancellationToken).ConfigureAwait(false);
            throw;
        }
    }

    private string? ProcessResponseContent(string? content)
    {
        if (content == null) return null;

        var response = JsonSerializer.Deserialize<AuthResponse>(content);
        if (response == null || string.IsNullOrEmpty(response.AccessToken))
            return ProcessPossibleError(response);

        var token = response.AccessToken.NotNull();
        if (response.ExpiresIn is > 1)
        {
            var expireInMillis = TimeSpan.FromSeconds(response.ExpiresIn.Value - 1).Milliseconds;
            SetToken(token, TimeUtils.NowInUtcMillis() + expireInMillis);
        }

        return token;
    }

    private string? ProcessPossibleError(AuthResponse? authResponse)
    {
        if (authResponse == null) return null;

        if (string.IsNullOrEmpty(authResponse.Error) && string.IsNullOrEmpty(authResponse.ErrorDescription))
            return null;

        var msg = new StringBuilder();
        msg.Append("Auth error");
        if (!string.IsNullOrEmpty(authResponse.Error)) 
        {
            msg.Append(": ").Append(authResponse.Error.NotNull());
        }
        if (!string.IsNullOrEmpty(authResponse.ErrorDescription))
        {
            msg.Append(": ").Append(authResponse.ErrorDescription.NotNull());
        }
        
        throw new AuthTokenFailureException(msg.ToString());
    }

    public class AuthResponse
    {
        [JsonPropertyName("access_token")]
        public string? AccessToken { get; set; }
        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }
        [JsonPropertyName("expires_in")]
        public int? ExpiresIn { get; set; }
        [JsonPropertyName("refresh_token")]
        public string? RefreshToken { get; set; }
        [JsonPropertyName("scope")]
        public string? Scope { get; set; }
        [JsonPropertyName("error")]
        public string? Error { get; set; }
        [JsonPropertyName("error_description")]
        public string? ErrorDescription { get; set; }
    }
}
