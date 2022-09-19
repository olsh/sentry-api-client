using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SentryApi.Client.Converters
{
    public class StatsJsonConverter : JsonConverter<List<StatsEntry>>
    {
        public override void WriteJson(JsonWriter writer, List<StatsEntry> value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override List<StatsEntry> ReadJson(JsonReader reader, Type objectType, List<StatsEntry> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var statsCollection = serializer.Deserialize<List<int []>>(reader);
            if (statsCollection == null)
            {
                return null;
            }

            var result = new List<StatsEntry>();
            foreach (var entry in statsCollection)
            {
                result.Add(new StatsEntry { DateTime = DateTimeOffset.FromUnixTimeSeconds(entry[0]), Count = entry[1]});
            }

            return result;
        }
    }
}
