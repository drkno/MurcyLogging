using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MurcyLogging.Agilefant
{
    public class BasicTag : IAgilefantTag
    {
        public Tag Tag { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public string Serialize()
        {
            return string.Format("#{0} {1}", Tag.ToString().ToLower(), Content);
        }
    }
}
