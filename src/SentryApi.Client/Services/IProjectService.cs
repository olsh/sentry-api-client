using System.Collections.Generic;
using System.Threading.Tasks;

namespace SentryApi.Client
{
    public interface IProjectService
    {
        Task<IReadOnlyCollection<Project>> GetAsync();
    }
}