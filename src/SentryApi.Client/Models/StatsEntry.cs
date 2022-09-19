using System;

namespace SentryApi.Client
{
    public class StatsEntry
    {
        public DateTimeOffset DateTime { get; set; }

        public long Count { get; set; }
    }
}
