using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurcyLogging.Agilefant
{
    public class MultiTag : IAgilefantTag
    {
        public Tag Tag { get; set; }
        public List<string> InfoPieces { get; private set; }

        public MultiTag()
        {
            InfoPieces = new List<string>();
        }

        public string AddInfo(object o)
        {
            InfoPieces.Add(o.ToString());
            return o.ToString();
        }

        public bool RemoveInfo(object o)
        {
            return InfoPieces.Remove(o.ToString());
        }

        public string Serialize()
        {
            var tagStart = "#" + Tag.ToString().ToLower();
            var builder = new StringBuilder();

            foreach (var piece in InfoPieces)
            {
                if (builder.Length != 0)
                    builder.Append(",");
                builder.Append(piece);
            }

            return string.Format("{0}[{1}]", tagStart, builder.ToString());
        }
    }
}
