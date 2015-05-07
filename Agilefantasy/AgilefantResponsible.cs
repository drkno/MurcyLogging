using Newtonsoft.Json;

namespace Agilefantasy
{
    public class AgilefantResponsible
    {
        [JsonProperty("class")]
        public string InternalClass { get; protected set; }
        [JsonProperty("id")]
        public int Id { get; protected set; }
        [JsonProperty("initials")]
        public string Initials { get; protected set; }
    }
}
