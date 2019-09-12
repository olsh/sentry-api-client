using Newtonsoft.Json;

namespace SentryApi.Client
{
    public class Status
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
