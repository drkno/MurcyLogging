#region

using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

#endregion

namespace Agilefantasy
{
    public class AgilefantUser
    {
        [JsonProperty("admin")]
        public bool Admin { get; protected set; }

        [JsonProperty("autoassignToStories")]
        public bool AutoassignToStories { get; protected set; }

        [JsonProperty("autoassignToTasks")]
        public bool AutoassignToTasks { get; protected set; }

        [JsonProperty("class")]
        public string InternalClass { get; protected set; }

        [JsonProperty("email")]
        public string Email { get; protected set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; protected set; }

        [JsonProperty("fullName")]
        public string Name { get; protected set; }

        [JsonProperty("id")]
        public int Id { get; protected set; }

        [JsonProperty("initials")]
        public string Initials { get; protected set; }

        [JsonProperty("loginName")]
        public string LoginName { get; protected set; }

        [JsonProperty("markStoryStarted")]
        public string MarkStoryStarted { get; protected set; }

        [JsonProperty("name")]
        public string UserCode { get; protected set; }

        [JsonProperty("recentItemsNumberOfWeeks")]
        public int RecentItemsNumberOfWeeks { get; protected set; }

        [JsonProperty("weekEffort")]
        public object WeekEffort { get; protected set; }

        internal static async Task<AgilefantUser[]> GetAgilefantUsers(AgilefantSession session)
        {
            var response = await session.Post("ajax/userChooserData.action");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            json = "{\"Users\":" + json + "}";

            var root = JsonConvert.DeserializeObject<AgilefantUserJsonRoot>(json);
            return (from afUser in root.Users select afUser.OriginalObject).ToArray();
        }

        protected class AgilefantUserJsonRoot
        {
            [JsonProperty]
            public AgilefantUserWrapper[] Users { get; protected set; }
        }

        protected class AgilefantUserWrapper
        {
            [JsonProperty("baseClassName")]
            public string BaseClassName { get; protected set; }

            [JsonProperty("enabled")]
            public bool Enabled { get; protected set; }

            [JsonProperty("id")]
            public int Id { get; protected set; }

            [JsonProperty("idList")]
            public object IdList { get; protected set; }

            [JsonProperty("matchedString")]
            public string MatchedString { get; protected set; }

            [JsonProperty("name")]
            public string Name { get; protected set; }

            [JsonProperty("originalObject")]
            public AgilefantUser OriginalObject { get; protected set; }
        }
    }
}