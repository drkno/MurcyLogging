using Agilefantasy.Agilefant.Common;
using Newtonsoft.Json;

namespace Agilefantasy.Agilefant
{
    public class AgilefantResponsible : AgilefantBase
    {
        [JsonProperty("initials")]
        public string Initials { get; protected set; }
    }
}
