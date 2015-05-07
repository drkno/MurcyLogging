using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Agilefantasy.Story
{
    public class AgilefantStory
    {
        [JsonProperty("class")]
        public string Class { get; protected set; }
        [JsonProperty("description")]
        public string Description { get; protected set; }
        [JsonProperty("effortSpent")]
        public int EffortSpent { get; protected set; }
        [JsonProperty("highestPoints")]
        public string HighestPoints { get; protected set; }
        [JsonProperty("id")]
        public int Id { get; protected set; }
        [JsonProperty("iteration")]
        public AgilefantSprintSummary Iteration { get; protected set; }
        [JsonProperty("labels")]
        public object[] Labels { get; protected set; }
        [JsonProperty("metrics")]
        public AgilefantStoryMetrics Metrics { get; protected set; }
        [JsonProperty("name")]
        public string Name { get; protected set; }
        [JsonProperty("parent")]
        public object Parent { get; protected set; }
        [JsonProperty("rank")]
        public int Rank { get; protected set; }
        [JsonProperty("responsibles")]
        public AgilefantResponsible[] AgilefantResponsibles { get; protected set; }
        [JsonProperty("state")]
        public string State { get; protected set; }
        [JsonProperty("storyPoints")]
        public int StoryPoints { get; protected set; }
        [JsonProperty("storyValue")]
        public object StoryValue { get; protected set; }
        [JsonProperty("tasks")]
        public Task[] Tasks { get; protected set; }
        [JsonProperty("treeRank")]
        public int TreeRank { get; protected set; }
        [JsonProperty("workQueueRank")]
        public object WorkQueueRank { get; protected set; }
    }
}
