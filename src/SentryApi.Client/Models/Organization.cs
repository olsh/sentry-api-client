using System;

using Newtonsoft.Json;

namespace SentryApi.Client
{
    public class Organization
    {
        [JsonProperty("avatar")]
        public Avatar Avatar { get; set; }

        [JsonProperty("dateCreated")]
        public DateTimeOffset DateCreated { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isEarlyAdopter")]
        public bool IsEarlyAdopter { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("require2FA")]
        public bool Require2Fa { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}
