using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SentryApi.Client
{
    internal sealed class SentryHttpClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        public SentryHttpClient(string token, HttpClient httpClient)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(token));
            }

            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            var responseMessage = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead)
                                      .ConfigureAwait(false);
            responseMessage.EnsureSuccessStatusCode();

            return responseMessage;
        }
    }
}
