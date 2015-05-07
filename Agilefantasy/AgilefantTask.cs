using Newtonsoft.Json;

namespace Agilefantasy
{
    public class AgilefantTask
    {
        [JsonProperty("class")]
        public string InternalClass { get; protected set; }
        [JsonProperty("description")]
        public string Description { get; protected set; }
        [JsonProperty("effortLeft")]
        public int EffortLeft { get; protected set; }
        [JsonProperty("effortSpent")]
        public int EffortSpent { get; protected set; }
        [JsonProperty("id")]
        public int Id { get; protected set; }
        [JsonProperty("name")]
        public string Name { get; protected set; }
        [JsonProperty("originalEstimate")]
        public int OriginalEstimate { get; protected set; }
        [JsonProperty("rank")]
        public int Rank { get; protected set; }
        [JsonProperty("responsibles")]
        public AgilefantResponsible[] AgilefantResponsibles { get; protected set; }
        [JsonProperty("state")]
        public string State { get; protected set; }
        [JsonProperty("workingOnTask")]
        public object[] WorkingOnTask { get; protected set; }
    }
}
