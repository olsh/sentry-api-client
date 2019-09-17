using System;
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

        public Task<PagedCollection<Project>> GetAsync()
        {
            return _sentryApiClient.GetPagedAsync<Project>("projects/");
        }

        public Task<Project> GetAsync(string organizationSlug, string projectSlug)
        {
            if (string.IsNullOrEmpty(organizationSlug))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(organizationSlug));
            }

            if (string.IsNullOrEmpty(projectSlug))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(projectSlug));
            }

            return _sentryApiClient.GetAsync<Project>($"projects/{organizationSlug}/{projectSlug}/");
        }
    }
}
