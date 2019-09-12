using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SentryApi.Client
{
    internal sealed class SentryHttpClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        public SentryHttpClient(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(token));
            }

            _httpClient = new HttpClient { BaseAddress = new Uri("https://sentry.io/api/0/") };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<HttpResponseMessage> SendAsync(HttpMethod method, string resource)
        {
            var responseMessage = await _httpClient.SendAsync(
                                          new HttpRequestMessage(method, resource),
                                          HttpCompletionOption.ResponseContentRead)
                                      .ConfigureAwait(false);

            return responseMessage;
        }
    }
}
