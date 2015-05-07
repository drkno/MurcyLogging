using System;
using System.Drawing;
using System.Threading.Tasks;
using Agilefantasy.Story;
using Newtonsoft.Json;

namespace Agilefantasy
{
    public class AgilefantSprint
    {
        /// <summary>
        /// Gets details about a sprint with a specified ID.
        /// </summary>
        /// <param name="sprintId">ID of the sprint to get.</param>
        /// <param name="session">Agilefant login session to use.</param>
        /// <returns>Details of the specified sprint.</returns>
        public static async Task<AgilefantSprint> GetSprint(int sprintId, AgilefantSession session)
        {
            var url = string.Format("iterationData.action?iterationId={0}", sprintId);
            var response = await session.Get(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AgilefantSprint>(json);
        }

        /// <summary>
        /// Downloads the burndown image for a sprint.
        /// </summary>
        /// <param name="sprintId">ID of sprint to get burndown for.</param>
        /// <param name="session">Agilefant login session to use.</param>
        /// <returns>The burndown image.</returns>
        public static async Task<Image> GenerateBurndownImage(int sprintId, AgilefantSession session)
        {
            var url = string.Format("drawIterationBurndown.action?backlogId={0}&timeZoneOffset=720", sprintId);
            var response = await session.Get(url);
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();
            return Image.FromStream(stream);
        }

        /// <summary>
        /// Gets the burndown image for this sprint.
        /// </summary>
        /// <param name="session">Agilefant session to use to get burndown image.</param>
        /// <returns>The burndown image.</returns>
        public async Task<Image> GetBurndownImage(AgilefantSession session)
        {
            return await GenerateBurndownImage(Id, session);
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
        public AgilefantStory[] RankedStories { get; protected set; }
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
    }
}
