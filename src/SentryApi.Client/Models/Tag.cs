using Newtonsoft.Json;

namespace SentryApi.Client
{
    public class Tag
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("_meta")]
        public object Meta { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
