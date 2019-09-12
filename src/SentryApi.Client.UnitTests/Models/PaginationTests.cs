using Xunit;

namespace SentryApi.Client.UnitTests.Models
{
    public class PaginationTests
    {
        [Fact]
        public void Valid_pagination_parsed_correctly()
        {
            var header = @"<https://sentry.io/api/0/projects/1/groups/?&cursor=1420837590:0:1>;
  rel=""previous""; results=""false"",
  <https://sentry.io/api/0/projects/1/groups/?&cursor=1420837533:0:0>;
  rel=""next""; results=""true""";

            Pagination.TryParse(header, out Pagination pagination);

            Assert.False(pagination.HasPrevious);
            Assert.True(pagination.HasNext);
            Assert.NotNull(pagination.PreviousLink);
            Assert.NotNull(pagination.NextLink);
        }
    }
}
