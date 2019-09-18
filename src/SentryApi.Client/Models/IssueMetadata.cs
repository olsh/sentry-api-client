using Newtonsoft.Json;

namespace SentryApi.Client
{
    public class IssueMetadata
    {
        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
