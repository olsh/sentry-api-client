using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace SentryApi.Client
{
    public class Event
    {
        [JsonProperty("dateCreated")]
        public DateTimeOffset DateCreated { get; set; }

        [JsonProperty("dateReceived")]
        public DateTimeOffset DateReceived { get; set; }

        [JsonProperty("dist")]
        public object Dist { get; set; }

        [JsonProperty("errors")]
        public List<object> Errors { get; set; }

        [JsonProperty("eventID")]
        public string EventId { get; set; }

        [JsonProperty("fingerprints")]
        public List<string> Fingerprints { get; set; }

        [JsonProperty("groupID")]
        public string GroupId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("_meta")]
        public Meta Meta { get; set; }

        [JsonProperty("nextEventID")]
        public object NextEventId { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("previousEventID")]
        public object PreviousEventId { get; set; }

        [JsonProperty("sdk")]
        public object Sdk { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
