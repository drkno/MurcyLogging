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
        public Task1[] tasks { get; protected set; }

        public class Assignee
        {
            [JsonProperty("class")]
            public string InternalClass { get; protected set; }
            [JsonProperty("Id")]
            public int Id { get; protected set; }
            [JsonProperty("initials")]
            public string Initials { get; protected set; }
        }

        public class Rankedstory
        {
            public string _class { get; protected set; }
            public string description { get; protected set; }
            public int effortSpent { get; protected set; }
            public string highestPoints { get; protected set; }
            public int id { get; protected set; }
            public AgilefantSprint iteration { get; protected set; }
            public object[] labels { get; protected set; }
            public Metrics metrics { get; protected set; }
            public string name { get; protected set; }
            public object parent { get; protected set; }
            public int rank { get; protected set; }
            public Responsible[] responsibles { get; protected set; }
            public string state { get; protected set; }
            public int storyPoints { get; protected set; }
            public object storyValue { get; protected set; }
            public Task[] tasks { get; protected set; }
            public int treeRank { get; protected set; }
            public object workQueueRank { get; protected set; }
        }

        public class Metrics
        {
            public string _class { get; protected set; }
            public int effortLeft { get; protected set; }
            public int effortSpent { get; protected set; }
            public int originalEstimate { get; protected set; }
        }

        public class Responsible
        {
            public string _class { get; protected set; }
            public int id { get; protected set; }
            public string initials { get; protected set; }
        }

        public class Task
        {
            public string _class { get; protected set; }
            public string description { get; protected set; }
            public int effortLeft { get; protected set; }
            public int effortSpent { get; protected set; }
            public int id { get; protected set; }
            public string name { get; protected set; }
            public int originalEstimate { get; protected set; }
            public int rank { get; protected set; }
            public Responsible1[] responsibles { get; protected set; }
            public string state { get; protected set; }
            public object[] workingOnTask { get; protected set; }
        }

        public class Responsible1
        {
            public string _class { get; protected set; }
            public int id { get; protected set; }
            public string initials { get; protected set; }
        }

        public class Task1
        {
            public string _class { get; protected set; }
            public string description { get; protected set; }
            public int effortLeft { get; protected set; }
            public int effortSpent { get; protected set; }
            public int id { get; protected set; }
            public string name { get; protected set; }
            public int originalEstimate { get; protected set; }
            public int rank { get; protected set; }
            public Responsible2[] responsibles { get; protected set; }
            public string state { get; protected set; }
            public object[] workingOnTask { get; protected set; }
        }

        public class Responsible2
        {
            public string _class { get; set; }
            public int id { get; set; }
            public string initials { get; set; }
        }














    }
}
