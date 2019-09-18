using System.Linq;
using System.Threading.Tasks;

using SentryApi.Client.IntegrationTests.Helpers;

using Xunit;

namespace SentryApi.Client.IntegrationTests.Services
{
    public class EventServiceTests
    {
        [Fact]
        public async Task Get_events_return_result()
        {
            var client = SentryApiClientFactory.Create();

            var projects = await client.Projects.GetAsync().ConfigureAwait(false);
            var project = projects.Collection.First();
            var events = await client.Events.GetAsync(new SentryRequest(project.Organization.Slug, project.Slug))
                             .ConfigureAwait(false);

            Assert.NotEmpty(events.Collection);
        }

        [Fact]
        public async Task Get_issues_return_result()
        {
            var client = SentryApiClientFactory.Create();

            var projects = await client.Projects.GetAsync().ConfigureAwait(false);
            var project = projects.Collection.First();
            var issues = await client.Events.GetIssuesAsync(new IssuesRequest(project.Organization.Slug, project.Slug))
                             .ConfigureAwait(false);

            Assert.NotEmpty(issues.Collection);
        }
    }
}
