namespace SentryApi.Client
{
    public class IssuesRequest : SentryRequest
    {
        public IssuesRequest(string organizationSlug, string projectSlug)
            : this(organizationSlug, projectSlug, null, StatsPeriod.Empty)
        {
        }

        public IssuesRequest(string organizationSlug, string projectSlug, string queryString)
            : this(organizationSlug, projectSlug, queryString, StatsPeriod.Empty)
        {
        }

        public IssuesRequest(string organizationSlug, string projectSlug, string queryString, StatsPeriod statsPeriod)
            : base(organizationSlug, projectSlug)
        {
            StatsPeriod = statsPeriod;
            QueryString = queryString;
        }

        public StatsPeriod StatsPeriod { get; }

        public string QueryString { get; }
    }
}
