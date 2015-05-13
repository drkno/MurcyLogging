using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agilefantasy
{
    /// <summary>
    /// Indicates an item can have time logged against it
    /// </summary>
    internal interface IAgilefantLoggable
    {
        /// <summary>
        /// The id of the item in the backlog
        /// </summary>
        int Id { get; }
    }
}
