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
        public Assignee[] Assignees { get; protected set; }
        [JsonProperty("backlogSize")]
        public int BacklogSize { get; protected set; }
        [JsonProperty("baselineLoad")]
        public object BaselineLoad { get; protected set; }
        [JsonProperty("class")]
        public string InternalClass { get; protected set; }
        [JsonProperty("description")]
        public string Description { get; protected set; }
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
        public int Id { get; protected set; }
        [JsonProperty("name")]
        public string Name { get; protected set; }
        [JsonProperty("product")]
        public bool Product { get; protected set; }
        [JsonProperty("rankedStories")]
        public Rankedstory[] RankedStories { get; protected set; }
        [JsonProperty("readonlyToken")]
        public object ReadonlyToken { get; protected set; }
        [JsonProperty("root")]
        public AgilefantBacklogProductSummary ProductSummary { get; protected set; }
        [JsonProperty("scheduleStatus")]
        public string ScheduleStatus { get; protected set; }
        [JsonProperty("standAlone")]
        public bool StandAlone { get; protected set; }
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
        public Task[] Tasks { get; protected set; }

        public class Assignee
        {
            [JsonProperty("class")]
            public string InternalClass { get; protected set; }
            [JsonProperty("id")]
            public int Id { get; protected set; }
            [JsonProperty("initials")]
            public string Initials { get; protected set; }
        }

        public class Rankedstory
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
            public AgilefantSprint Iteration { get; protected set; }
            [JsonProperty("labels")]
            public object[] Labels { get; protected set; }
            [JsonProperty("metrics")]
            public Metrics Metrics { get; protected set; }
            [JsonProperty("name")]
            public string Name { get; protected set; }
            [JsonProperty("parent")]
            public object Parent { get; protected set; }
            [JsonProperty("rank")]
            public int Rank { get; protected set; }
            [JsonProperty("responsibles")]
            public Responsible[] Responsibles { get; protected set; }
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

        public class Metrics
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

        public class Responsible
        {
            [JsonProperty("class")]
            public string InternalClass { get; protected set; }
            [JsonProperty("id")]
            public int Id { get; protected set; }
            [JsonProperty("initials")]
            public string Initials { get; protected set; }
        }

        public class Task
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
            public Responsible[] Responsibles { get; protected set; }
            [JsonProperty("state")]
            public string State { get; protected set; }
            [JsonProperty("workingOnTask")]
            public object[] WorkingOnTask { get; protected set; }
        }

        
    }
}
