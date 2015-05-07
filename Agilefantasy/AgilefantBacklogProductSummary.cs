using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Agilefantasy
{
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
