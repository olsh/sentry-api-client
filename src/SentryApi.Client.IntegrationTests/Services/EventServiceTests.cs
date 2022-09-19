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
            var exception =
                await Record.ExceptionAsync(async () => await client.Events.GetAsync(new SentryRequest(project.Organization.Slug, project.Slug)).ConfigureAwait(false));

            Assert.Null(exception);
        }

        [Fact]
        public async Task Get_issues_return_result()
        {
            var client = SentryApiClientFactory.Create();

            var projects = await client.Projects.GetAsync().ConfigureAwait(false);
            var project = projects.Collection.First();
            var exception =
                await Record.ExceptionAsync(async () => await client.Events.GetIssuesAsync(new IssuesRequest(project.Organization.Slug, project.Slug)).ConfigureAwait(false));

            Assert.Null(exception);
        }

        [Fact]
        public async Task Get_issues_with_filter_doest_thrown_an_exception()
        {
            var client = SentryApiClientFactory.Create();

            var projects = await client.Projects.GetAsync().ConfigureAwait(false);
            var project = projects.Collection.First();
            var exception =
                await Record.ExceptionAsync(async () => await client.Events.GetIssuesAsync(new IssuesRequest(project.Organization.Slug, project.Slug, "is:unresolved is:assigned", StatsPeriod.Day)).ConfigureAwait(false));

            Assert.Null(exception);
        }
    }
}
