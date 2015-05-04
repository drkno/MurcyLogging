#region

using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

#endregion

namespace Agilefantasy
{
    public class AgilefantBacklog
    {
        [JsonProperty("backlogSize")]
        public object BacklogSize { get; set; }

        [JsonProperty("baselineLoad")]
        public int BaselineLoad { get; set; }

        [JsonProperty("class")]
        public string InternalClass { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("endDate")]
        public long EndDate { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("product")]
        public bool Product { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("root")]
        public AgilefantBacklogProductSummary Root { get; set; }

        [JsonProperty("standAlone")]
        public bool StandAlone { get; set; }

        [JsonProperty("startDate")]
        public long StartDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets an array of the backlogs for a team
        /// </summary>
        /// <param name="teamNumber">The team to get the backlog for</param>
        /// <param name="session">The session to operate within</param>
        /// <returns>The backlogs</returns>
        internal static async Task<AgilefantBacklog[]> GetAgilefantBacklogs(int teamNumber, AgilefantSession session)
        {
            var response = await session.Post("ajax/retrieveSubBacklogs.action", new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"backlogId=", teamNumber.ToString()}
            }));
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AgilefantBacklog[]>(json);
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