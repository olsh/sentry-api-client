using System.Threading.Tasks;

namespace SentryApi.Client
{
    internal interface IAdvancedSentryApiClient
    {
        Task<T> GetAsync<T>(string resource);

        Task<PagedCollection<T>> GetPagedAsync<T>(string resource);
    }
}
