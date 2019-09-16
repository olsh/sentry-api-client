using System.Threading.Tasks;

namespace SentryApi.Client
{
    public interface ISentryApiClient
    {
        Task<PagedCollection<T>> LoadNextPageAsync<T>(PagedCollection<T> collection);

        Task<PagedCollection<T>> LoadPreviousPageAsync<T>(PagedCollection<T> collection);
    }
}