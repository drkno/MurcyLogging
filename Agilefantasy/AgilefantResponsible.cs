using Agilefantasy.Common;
using Newtonsoft.Json;

namespace Agilefantasy
{
    public class AgilefantResponsible : AgilefantBase
    {
        [JsonProperty("initials")]
        public string Initials { get; protected set; }
    }
}
