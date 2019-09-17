using System.Collections.Generic;
using System.Linq;
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

            var allProjects = new List<Project>(pagedCollection.Collection);
            while (pagedCollection.Pagination.HasNext)
            {
                pagedCollection = await client.LoadNextPageAsync(pagedCollection);
                allProjects.AddRange(pagedCollection.Collection);
            }

            Assert.NotEmpty(pagedCollection.Collection);
        }

        [Fact]
        public async Task Get_project_by_slug_returns_project()
        {
            var client = SentryApiClientFactory.Create();

            var pagedCollection = await client.Projects.GetAsync();
            var firstProject = pagedCollection.Collection.First();

            var project = await client.Projects.GetAsync(firstProject.Organization.Slug, firstProject.Slug);

            Assert.NotNull(project);
        }
    }
}
