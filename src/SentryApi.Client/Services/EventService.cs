using System;
using System.Collections.Generic;
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

            string path = $"projects/{request.OrganizationSlug}/{request.ProjectSlug}/issues/";

            var parameters = new List<string>();
            if (request.Period != null)
            {
                parameters.Add($"statsPeriod={request.Period}");
            }

            if (!string.IsNullOrEmpty(request.QueryString))
            {
                parameters.Add($"query={request.QueryString}");
            }

            if (parameters.Count > 0)
            {
                path += $"?{string.Join("&", parameters)}";
            }

            return _sentryApiClient.GetPagedAsync<Issue>(path);
        }
    }
}
