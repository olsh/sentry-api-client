namespace SentryApi.Client
{
    public class IssuesRequest : SentryRequest
    {
        public IssuesRequest(
            string organizationSlug,
            string projectSlug,
            Period period = null,
            string queryString = null)
            : base(organizationSlug, projectSlug)
        {
            Period = period;
            QueryString = queryString;
        }

        public Period Period { get; }

        public string QueryString { get; }
    }
}
