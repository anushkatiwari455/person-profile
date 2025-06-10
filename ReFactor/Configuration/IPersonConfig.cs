using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReFactor.Configuration
{
    public interface IPersonConfig
    {
        int MinimumAge { get; }
        int MaximumAge { get; }
        int MaxNameLength { get; }
        int AgeForFilter { get; }
        string[] NamesPool { get; }
        string DisallowedLastNameSubstring { get; }
    }
}
