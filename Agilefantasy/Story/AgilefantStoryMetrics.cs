using Newtonsoft.Json;

namespace Agilefantasy
{
    public class AgilefantStoryMetrics
    {
        [JsonProperty("class")]
        public string InternalClass { get; protected set; }
        [JsonProperty("effortLeft")]
        public int EffortLeft { get; protected set; }
        [JsonProperty("effortSpent")]
        public int EffortSpent { get; protected set; }
        [JsonProperty("originalEstimate")]
        public int OriginalEstimate { get; protected set; }
    }
}