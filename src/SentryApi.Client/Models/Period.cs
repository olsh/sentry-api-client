namespace SentryApi.Client
{
    public class Period : StringEnum
    {
        private Period(string value)
            : base(value)
        {
        }

        public static Period All => new Period(string.Empty);

        public static Period Day => new Period("24h");

        public static Period FourteenDays => new Period("14d");
    }
}
