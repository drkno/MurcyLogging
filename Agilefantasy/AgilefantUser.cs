﻿#region

using System.Linq;
using System.Threading.Tasks;
using Agilefantasy.Common;
using Newtonsoft.Json;

#endregion

namespace Agilefantasy
{
    public class AgilefantUser : AgilefantBase
    {
        [JsonProperty("admin")]
        public bool Admin { get; private set; }

        [JsonProperty("autoassignToStories")]
        public bool AutoassignToStories { get; private set; }

        [JsonProperty("autoassignToTasks")]
        public bool AutoassignToTasks { get; private set; }

        [JsonProperty("email")]
        public string Email { get; private set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; private set; }

        [JsonProperty("fullName")]
        public string Name { get; private set; }

        [JsonProperty("initials")]
        public string Initials { get; private set; }

        [JsonProperty("loginName")]
        public string LoginName { get; private set; }

        [JsonProperty("markStoryStarted")]
        public string MarkStoryStarted { get; private set; }

        [JsonProperty("name")]
        public string UserCode { get; private set; }

        [JsonProperty("recentItemsNumberOfWeeks")]
        public int RecentItemsNumberOfWeeks { get; private set; }

        [JsonProperty("weekEffort")]
        public object WeekEffort { get; private set; }

        internal static async Task<AgilefantUser[]> GetAgilefantUsers(AgilefantSession session)
        {
            var response = await session.Post("ajax/userChooserData.action");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var wrappers = JsonConvert.DeserializeObject<AgilefantUserWrapper[]>(json);
            return (from wrapper in wrappers select wrapper.OriginalObject).ToArray();
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", LoginName, Name);
        }

        protected class AgilefantUserWrapper
        {
            [JsonProperty("baseClassName")]
            public string BaseClassName { get; private set; }

            [JsonProperty("enabled")]
            public bool Enabled { get; private set; }

            [JsonProperty("id")]
            public int Id { get; private set; }

            [JsonProperty("idList")]
            public object IdList { get; private set; }

            [JsonProperty("matchedString")]
            public string MatchedString { get; private set; }

            [JsonProperty("name")]
            public string Name { get; private set; }

            [JsonProperty("originalObject")]
            public AgilefantUser OriginalObject { get; private set; }
        }
    }
}