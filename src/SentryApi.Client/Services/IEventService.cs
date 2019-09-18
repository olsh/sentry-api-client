using System.Threading.Tasks;

namespace SentryApi.Client
{
    public interface IEventService
    {
        Task<PagedCollection<Event>> GetAsync(SentryRequest request);

        Task<Event> GetAsync(EventRequest request);

        Task<PagedCollection<Issue>> GetIssuesAsync(IssuesRequest request);
    }
}
