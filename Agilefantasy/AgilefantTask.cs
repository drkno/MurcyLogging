using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Agilefantasy.Common;
using Newtonsoft.Json;

namespace Agilefantasy
{
    public class AgilefantTask : AgilefantBase
    {
        [JsonProperty("description")]
        public string Description { get; private set; }
        [JsonProperty("effortLeft")]
        public int EffortLeft { get; private set; }
        [JsonProperty("effortSpent")]
        public int EffortSpent { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("originalEstimate")]
        public int OriginalEstimate { get; private set; }
        [JsonProperty("rank")]
        public int Rank { get; private set; }
        [JsonProperty("responsibles")]
        public AgilefantResponsible[] AgilefantResponsibles { get; private set; }
        [JsonProperty("state")]
        public string State { get; private set; }
        [JsonProperty("workingOnTask")]
        public object[] WorkingOnTask { get; private set; }

        public static Task AddTask(AgilefantBase parentObject, DateTime entryDate, int minutesSpent, string description,
            IEnumerable<AgilefantUser> users, AgilefantSession session)
        {
            //Get the time in milliseconds since the epoch
            var timeSinceEpoch = (int)(entryDate - new DateTime(1970, 1, 1)).TotalMilliseconds;
            
            //Get a comma seperated string of the users
            var userIds = "";
            foreach (var user in users)
            {
                if (!string.IsNullOrEmpty(userIds))
                    userIds += ",";
                userIds += user.Id;
            }
            
            var postData = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"parentObjectId", parentObject.Id.ToString()},
                {"hourEntry.date", timeSinceEpoch.ToString()},
                {"hourEntry.minutesSpent", minutesSpent.ToString()},
                {"hourEntry.description", description},
                {"userIds", userIds},
            });

            return session.Post("ajax/logTaskEffort.action", postData);
        }
    }
}
