using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Agilefantasy
{
    public class AgilefantDetailedSprint
    {
        /// <summary>
        /// Gets all Agilefant stories within a sprint.
        /// </summary>
        /// <param name="sprintId">ID of the sprint to get the stories of.</param>
        /// <param name="session">Agilefant login session to use.</param>
        /// <returns>An array of Agilefant stories within a sprint.</returns>
        public static async Task<AgilefantDetailedSprint> GetStories(int sprintId, AgilefantSession session)
        {
            var url = string.Format("iterationData.action?iterationId={0}", sprintId);
            var response = await session.Get(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AgilefantDetailedSprint>(json);
        }

        [JsonProperty("assignees")]
        public Assignee[] Assignees { get; set; }
        [JsonProperty("backlogSize")]
        public int BacklogSize { get; set; }
        [JsonProperty("baselineLoad")]
        public object BaselineLoad { get; set; }
        [JsonProperty("class")]
        public string InternalClass { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("endDate")]
        protected long EndDateLong { get; set; }

        public DateTime EndTime
        {
            get
            {
                return new DateTime(1970, 1, 1).AddMilliseconds(EndDateLong);
            }
        }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("product")]
        public bool Product { get; set; }
        [JsonProperty("rankedStories")]
        public Rankedstory[] RankedStories { get; set; }
        [JsonProperty("readonlyToken")]
        public object ReadonlyToken { get; set; }
        [JsonProperty("root")]
        public AgilefantBacklogProductSummary ProductSummary { get; set; }
        [JsonProperty("scheduleStatus")]
        public string ScheduleStatus { get; set; }
        [JsonProperty("standAlone")]
        public bool StandAlone { get; set; }
        [JsonProperty("startDate")]
        protected long StartDateLong { get; set; }

        public DateTime StartDate
        {
            get
            {
                return new DateTime(1970, 1, 1).AddMilliseconds(StartDateLong);
            }
        }

        [JsonProperty("tasks")]
        public Task[] Tasks { get; set; }

        public class Assignee
        {
            [JsonProperty("class")]
            public string InternalClass { get; set; }
            [JsonProperty("id")]
            public int Id { get; set; }
            [JsonProperty("initials")]
            public string Initials { get; set; }
        }

        public class Rankedstory
        {
            [JsonProperty("class")]
            public string Class { get; set; }
            [JsonProperty("description")]
            public string Description { get; set; }
            [JsonProperty("effortSpent")]
            public int EffortSpent { get; set; }
            [JsonProperty("highestPoints")]
            public string HighestPoints { get; set; }
            [JsonProperty("id")]
            public int Id { get; set; }
            [JsonProperty("iteration")]
            public AgilefantSprint Iteration { get; set; }
            [JsonProperty("labels")]
            public object[] Labels { get; set; }
            [JsonProperty("metrics")]
            public Metrics Metrics { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("parent")]
            public object Parent { get; set; }
            [JsonProperty("rank")]
            public int Rank { get; set; }
            [JsonProperty("responsibles")]
            public Responsible[] Responsibles { get; set; }
            [JsonProperty("state")]
            public string State { get; set; }
            [JsonProperty("storyPoints")]
            public int StoryPoints { get; set; }
            [JsonProperty("storyValue")]
            public object StoryValue { get; set; }
            [JsonProperty("tasks")]
            public Task[] Tasks { get; set; }
            [JsonProperty("treeRank")]
            public int TreeRank { get; set; }
            [JsonProperty("workQueueRank")]
            public object WorkQueueRank { get; set; }
        }

        public class Metrics
        {
            [JsonProperty("class")]
            public string InternalClass { get; set; }
            [JsonProperty("effortLeft")]
            public int EffortLeft { get; set; }
            [JsonProperty("effortSpent")]
            public int EffortSpent { get; set; }
            [JsonProperty("originalEstimate")]
            public int OriginalEstimate { get; set; }
        }

        public class Responsible
        {
            [JsonProperty("class")]
            public string InternalClass { get; set; }
            [JsonProperty("id")]
            public int Id { get; set; }
            [JsonProperty("initials")]
            public string Initials { get; set; }
        }

        public class Task
        {
            [JsonProperty("class")]
            public string InternalClass { get; set; }
            [JsonProperty("description")]
            public string Description { get; set; }
            [JsonProperty("effortLeft")]
            public int EffortLeft { get; set; }
            [JsonProperty("effortSpent")]
            public int EffortSpent { get; set; }
            [JsonProperty("id")]
            public int Id { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("originalEstimate")]
            public int OriginalEstimate { get; set; }
            [JsonProperty("rank")]
            public int Rank { get; set; }
            [JsonProperty("responsibles")]
            public Responsible[] Responsibles { get; set; }
            [JsonProperty("state")]
            public string State { get; set; }
            [JsonProperty("workingOnTask")]
            public object[] WorkingOnTask { get; set; }
        }

        
    }
}
