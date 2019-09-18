using System.Threading.Tasks;

namespace SentryApi.Client
{
    public interface IProjectService
    {
        Task<PagedCollection<Project>> GetAsync();

        Task<Project> GetAsync(SentryRequest request);
    }
}
