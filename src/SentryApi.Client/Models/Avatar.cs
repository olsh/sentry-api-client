using Newtonsoft.Json;

namespace SentryApi.Client
{
    public class Avatar
    {
        [JsonProperty("avatarType")]
        public string AvatarType { get; set; }

        [JsonProperty("avatarUuid")]
        public string AvatarUuid { get; set; }
    }
}
