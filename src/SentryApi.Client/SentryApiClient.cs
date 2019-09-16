using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace SentryApi.Client
{
    public class SentryApiClient : IDisposable, IAdvancedSentryApiClient, ISentryApiClient
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

        async Task<PagedCollection<T>> IAdvancedSentryApiClient.GetPagedAsync<T>(string resource)
        {
            var response = await _sentryHttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, resource))
                               .ConfigureAwait(false);

            var pagedCollection = new PagedCollection<T>
                                      {
                                          Collection = await DeserializeBodyAsync<IReadOnlyCollection<T>>(response).ConfigureAwait(false)
                                      };

            // ReSharper disable PossibleMultipleEnumeration
            if (response.Headers.TryGetValues("link", out var linkValues)
                && linkValues.Count() == 1
                && Pagination.TryParse(linkValues.First(), out var pagination))
            {
                pagedCollection.Pagination = pagination;
            }
            // ReSharper restore PossibleMultipleEnumeration

            return pagedCollection;
        }

        public Task<PagedCollection<T>> LoadNextPageAsync<T>(PagedCollection<T> collection)
        {
            return ((IAdvancedSentryApiClient)this).GetPagedAsync<T>(collection.Pagination.NextLink.ToString());
        }

        public Task<PagedCollection<T>> LoadPreviousPageAsync<T>(PagedCollection<T> collection)
        {
            return ((IAdvancedSentryApiClient)this).GetPagedAsync<T>(collection.Pagination.PreviousLink.ToString());
        }

        async Task<T> IAdvancedSentryApiClient.GetAsync<T>(string resource)
        {
            var response = await _sentryHttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, resource))
                               .ConfigureAwait(false);

            return await DeserializeBodyAsync<T>(response).ConfigureAwait(false);
        }

        private async Task<T> DeserializeBodyAsync<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync()
                              .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
