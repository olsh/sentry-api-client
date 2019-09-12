using System.Net.Http;
using System.Threading.Tasks;

namespace SentryApi.Client
{
    internal interface IAdvancedSentryApiClient
    {
        Task<T> ExecuteAsync<T>(HttpMethod method, string resource);
    }
}