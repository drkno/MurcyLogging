#region

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

#endregion

namespace Agilefantasy
{
    public class AgilefantSprint
    {
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

        public DateTime EndDate
        {
            get { return new DateTime(1970, 1, 1).AddMilliseconds(EndDateLong); }
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("product")]
        public bool Product { get; set; }

        [JsonProperty("readonlyToken")]
        public object ReadonlyToken { get; set; }

        [JsonProperty("root")]
        public AgilefantBacklogProductSummary Root { get; set; }

        [JsonProperty("standAlone")]
        public bool StandAlone { get; set; }

        [JsonProperty("startDate")]
        protected long StartDateLong { get; set; }

        public DateTime StartDate
        {
            get { return new DateTime(1970, 1, 1).AddMilliseconds(StartDateLong); }
        }

        /// <summary>
        /// Gets an array of sprints available 
        /// </summary>
        /// <param name="session">The session</param>
        /// <returns>The sprint</returns>
        internal static async Task<AgilefantSprint[]> GetSprints(AgilefantSession session)
        {
            var response = await session.Post("ajax/retrieveSubBacklogs.action");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AgilefantSprint[]>(json);
        }

        public class AgilefantBacklogProductSummary
        {
            [JsonProperty("class")]
            public string InternalClass { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("product")]
            public bool Product { get; set; }

            [JsonProperty("standAlone")]
            public bool StandAlone { get; set; }
        }
    }
}