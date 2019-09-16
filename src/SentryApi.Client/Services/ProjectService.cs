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
    }
}
