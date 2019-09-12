using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SentryApi.Client
{
    public class ProjectService : IProjectService
    {
        private readonly IAdvancedSentryApiClient _sentryApiClient;

        internal ProjectService(IAdvancedSentryApiClient sentryApiClient)
        {
            _sentryApiClient = sentryApiClient;
        }

        public Task<IReadOnlyCollection<Project>> GetAsync()
        {
            return _sentryApiClient.ExecuteAsync<IReadOnlyCollection<Project>>(HttpMethod.Get, "projects/");
        }
    }
}
