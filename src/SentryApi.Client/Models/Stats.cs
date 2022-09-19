using Newtonsoft.Json;
using SentryApi.Client.Converters;
using System.Collections.Generic;

namespace SentryApi.Client
{
    public class Stats
    {
        [JsonConverter(typeof(StatsJsonConverter))]
        [JsonProperty("24h")]
        public List<StatsEntry> OneDay { get; set; }

        [JsonConverter(typeof(StatsJsonConverter))]
        [JsonProperty("14d")]
        public List<StatsEntry> TwoWeeks { get; set; }
    }
}
