using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurcyLogging.Agilefant
{
    public interface IAgilefantTag
    {
        Tag Tag { get; }

        string Serialize();
    }
}
