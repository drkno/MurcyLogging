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
        public Task1[] tasks { get; set; }

        public class Assignee
        {
            [JsonProperty("class")]
            public string InternalClass { get; set; }
            [JsonProperty("Id")]
            public int Id { get; set; }
            [JsonProperty("initials")]
            public string Initials { get; set; }
        }

        public class Rankedstory
        {
            public string _class { get; set; }
            public string description { get; set; }
            public int effortSpent { get; set; }
            public string highestPoints { get; set; }
            public int id { get; set; }
            public AgilefantSprint iteration { get; set; }
            public object[] labels { get; set; }
            public Metrics metrics { get; set; }
            public string name { get; set; }
            public object parent { get; set; }
            public int rank { get; set; }
            public Responsible[] responsibles { get; set; }
            public string state { get; set; }
            public int storyPoints { get; set; }
            public object storyValue { get; set; }
            public Task[] tasks { get; set; }
            public int treeRank { get; set; }
            public object workQueueRank { get; set; }
        }

        public class Metrics
        {
            public string _class { get; set; }
            public int effortLeft { get; set; }
            public int effortSpent { get; set; }
            public int originalEstimate { get; set; }
        }

        public class Responsible
        {
            public string _class { get; set; }
            public int id { get; set; }
            public string initials { get; set; }
        }

        public class Task
        {
            public string _class { get; set; }
            public string description { get; set; }
            public int effortLeft { get; set; }
            public int effortSpent { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int originalEstimate { get; set; }
            public int rank { get; set; }
            public Responsible1[] responsibles { get; set; }
            public string state { get; set; }
            public object[] workingOnTask { get; set; }
        }

        public class Responsible1
        {
            public string _class { get; set; }
            public int id { get; set; }
            public string initials { get; set; }
        }

        public class Task1
        {
            public string _class { get; set; }
            public string description { get; set; }
            public int effortLeft { get; set; }
            public int effortSpent { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int originalEstimate { get; set; }
            public int rank { get; set; }
            public Responsible2[] responsibles { get; set; }
            public string state { get; set; }
            public object[] workingOnTask { get; set; }
        }

        public class Responsible2
        {
            public string _class { get; set; }
            public int id { get; set; }
            public string initials { get; set; }
        }














    }
}
