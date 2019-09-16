using System.Threading.Tasks;

using SentryApi.Client.IntegrationTests.Helpers;

using Xunit;

namespace SentryApi.Client.IntegrationTests.Services
{
    public class ProjectServiceTests
    {
        [Fact]
        public async Task Get_projects_returns_any_projects()
        {
            var client = SentryApiClientFactory.Create();

            var pagedCollection = await client.Projects.GetAsync();

            Assert.NotEmpty(pagedCollection.Collection);
        }
    }
}
