using System;
using System.ComponentModel;

namespace SentryApi.Client
{
    public class Period
    {
        public Period(int amount, PeriodType type)
        {
            if (!Enum.IsDefined(typeof(PeriodType), type))
            {
                throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(PeriodType));
            }

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            Amount = amount;
            Type = type;
        }

        public int Amount { get; }

        public PeriodType Type { get; }

        internal string ToQueryString()
        {
            var typeString = Type == PeriodType.Day ? "d" : "h";

            return $"{Amount}{typeString}";
        }
    }
}
