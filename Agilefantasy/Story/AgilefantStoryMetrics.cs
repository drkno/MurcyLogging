using Agilefantasy.Common;
using Newtonsoft.Json;

namespace Agilefantasy.Story
{
    public class AgilefantStoryMetrics : AgilefantBase
    {
        [JsonProperty("effortLeft")]
        public int EffortLeft { get; private set; }
        [JsonProperty("effortSpent")]
        public int EffortSpent { get; private set; }
        [JsonProperty("originalEstimate")]
        public int OriginalEstimate { get; private set; }
    }
}