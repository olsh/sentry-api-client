using System.Linq;
using System.Threading.Tasks;

using SentryApi.Client.IntegrationTests.Helpers;

using Xunit;

namespace SentryApi.Client.IntegrationTests
{
    public class SentryApiClientTests
    {
        [Fact]
        public async Task Move_forward_and_back_collection_has_the_same_projects()
        {
            var client = SentryApiClientFactory.Create();

            var collection = await client.Projects.GetAsync().ConfigureAwait(false);
            var nextPage = await client.LoadNextPageAsync(collection);
            var previousPage = await client.LoadPreviousPageAsync(nextPage);

            Assert.Contains(previousPage.Collection, project => collection.Collection.Any(c => c.Slug == project.Slug));
        }
    }
}
