namespace SentryApi.Client
{
    public class IssuesRequest : SentryRequest
    {
        public IssuesRequest(string organizationSlug, string projectSlug)
            : this(organizationSlug, projectSlug, null, Period.All)
        {
        }

        public IssuesRequest(string organizationSlug, string projectSlug, string queryString)
            : this(organizationSlug, projectSlug, queryString, Period.All)
        {
        }

        public IssuesRequest(string organizationSlug, string projectSlug, string queryString, Period period)
            : base(organizationSlug, projectSlug)
        {
            Period = period;
            QueryString = queryString;
        }

        public Period Period { get; }

        public string QueryString { get; }
    }
}
