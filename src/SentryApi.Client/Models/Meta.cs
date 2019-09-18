using Newtonsoft.Json;

namespace SentryApi.Client
{
    public class Meta
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("sdk")]
        public string Sdk { get; set; }
    }
}
