using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace SentryApi.Client
{
    public class Issue
    {
        [JsonProperty("annotations")]
        public List<dynamic> Annotations { get; set; }

        [JsonProperty("assignedTo")]
        public Assignee AssignedTo { get; set; }

        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("culprit")]
        public string Culprit { get; set; }

        [JsonProperty("firstSeen")]
        public DateTimeOffset FirstSeen { get; set; }

        [JsonProperty("hasSeen")]
        public bool HasSeen { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isBookmarked")]
        public bool IsBookmarked { get; set; }

        [JsonProperty("isPublic")]
        public bool IsPublic { get; set; }

        [JsonProperty("isSubscribed")]
        public bool IsSubscribed { get; set; }

        [JsonProperty("lastSeen")]
        public DateTimeOffset LastSeen { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("logger")]
        public string Logger { get; set; }

        [JsonProperty("metadata")]
        public IssueMetadata Metadata { get; set; }

        [JsonProperty("numComments")]
        public long NumComments { get; set; }

        [JsonProperty("permalink")]
        public Uri Permalink { get; set; }

        [JsonProperty("project")]
        public Project Project { get; set; }

        [JsonProperty("shortId")]
        public string ShortId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("userCount")]
        public long UserCount { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }
    }
}
