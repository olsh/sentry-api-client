namespace SentryApi.Client
{
    public class StatsPeriod : StringEnum
    {
        private StatsPeriod(string value)
            : base(value)
        {
        }

        public static StatsPeriod Empty => new StatsPeriod(string.Empty);

        public static StatsPeriod Day => new StatsPeriod("24h");

        public static StatsPeriod TwoWeeks => new StatsPeriod("14d");
    }
}
