using System;

using Newtonsoft.Json;

namespace SentryApi.Client
{
    public class Project
    {
        [JsonProperty("avatar")]
        public Avatar Avatar { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("dateCreated")]
        public DateTimeOffset DateCreated { get; set; }

        [JsonProperty("features")]
        public string[] Features { get; set; }

        [JsonProperty("firstEvent")]
        public object FirstEvent { get; set; }

        [JsonProperty("hasAccess")]
        public bool HasAccess { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isBookmarked")]
        public bool IsBookmarked { get; set; }

        [JsonProperty("isInternal")]
        public bool IsInternal { get; set; }

        [JsonProperty("isMember")]
        public bool IsMember { get; set; }

        [JsonProperty("isPublic")]
        public bool IsPublic { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("organization")]
        public Organization Organization { get; set; }

        [JsonProperty("platform")]
        public object Platform { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
