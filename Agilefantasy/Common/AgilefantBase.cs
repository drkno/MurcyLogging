using Newtonsoft.Json;

namespace Agilefantasy.Common
{
    public abstract class AgilefantBase
    {
        [JsonProperty("class")]
        protected string InternalClass { get; set; }

        [JsonProperty("id")]
        public int Id { get; protected set; }
    }
}
