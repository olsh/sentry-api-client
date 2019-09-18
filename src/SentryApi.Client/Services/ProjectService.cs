using System;
using System.Threading.Tasks;

namespace SentryApi.Client
{
    internal class ProjectService : IProjectService
    {
        private readonly IAdvancedSentryApiClient _sentryApiClient;

        internal ProjectService(IAdvancedSentryApiClient sentryApiClient)
        {
            _sentryApiClient = sentryApiClient;
        }

        public Task<PagedCollection<Project>> GetAsync()
        {
            return _sentryApiClient.GetPagedAsync<Project>("projects/");
        }

        public Task<Project> GetAsync(SentryRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return _sentryApiClient.GetAsync<Project>($"projects/{request.OrganizationSlug}/{request.ProjectSlug}/");
        }
    }
}
