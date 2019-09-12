using System;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace SentryApi.Client
{
    public class SentryApiClient : IDisposable, IAdvancedSentryApiClient
    {
        private readonly SentryHttpClient _sentryHttpClient;

        public SentryApiClient(string token)
        {
            _sentryHttpClient = new SentryHttpClient(token);

            Projects = new ProjectService(this);
        }

        public IProjectService Projects { get; }

        public void Dispose()
        {
            _sentryHttpClient.Dispose();
        }

        async Task<T> IAdvancedSentryApiClient.ExecuteAsync<T>(HttpMethod method, string resource)
        {
            var response = await _sentryHttpClient.SendAsync(method, resource)
                               .ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync()
                              .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
