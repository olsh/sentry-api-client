using System;
using System.Threading.Tasks;

namespace SentryApi.Client
{
    internal class EventService : IEventService
    {
        private readonly IAdvancedSentryApiClient _sentryApiClient;

        public EventService(IAdvancedSentryApiClient sentryApiClient)
        {
            _sentryApiClient = sentryApiClient;
        }

        public Task<PagedCollection<Event>> GetAsync(SentryRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return _sentryApiClient.GetPagedAsync<Event>(
                $"projects/{request.OrganizationSlug}/{request.ProjectSlug}/events/");
        }

        public Task<Event> GetAsync(EventRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return _sentryApiClient.GetAsync<Event>(
                $"projects/{request.OrganizationSlug}/{request.ProjectSlug}/events/{request.Id}");
        }

        public Task<PagedCollection<Issue>> GetIssuesAsync(IssuesRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var queryString = $"projects/{request.OrganizationSlug}/{request.ProjectSlug}/issues/";
            if (request.Period != null || !string.IsNullOrEmpty(request.QueryString))
            {
                queryString += "?";
            }

            if (request.Period != null)
            {
                queryString += $"statsPeriod={request.Period.ToQueryString()}";
            }

            if (!string.IsNullOrEmpty(request.QueryString))
            {
                queryString += queryString;
            }

            return _sentryApiClient.GetPagedAsync<Issue>(queryString);
        }
    }
}
