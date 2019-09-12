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

            var projects = await client.Projects.GetAsync();

            Assert.NotEmpty(projects);
        }
    }
}
