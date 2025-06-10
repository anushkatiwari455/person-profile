using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReFactor.Configuration
{
    public class PersonConfig : IPersonConfig
    {
        private int _minimumAge = 18;
        private int _maximumAge = 85;
        private int _maxNameLength = 255;
        private int _ageForFilter = 30;
        private string[] _namesPool = new[] { "Bob", "Betty" };
        private string _disallowedLastNameSubstring = "test";

        public int MinimumAge
        {
            get { return _minimumAge; }
            set { _minimumAge = value; }
        }

        public int MaximumAge
        {
            get { return _maximumAge; }
            set { _maximumAge = value; }
        }

        public int MaxNameLength
        {
            get { return _maxNameLength; }
            set { _maxNameLength = value; }
        }

        public int AgeForFilter
        {
            get { return _ageForFilter; }
            set { _ageForFilter = value; }
        }

        public string[] NamesPool
        {
            get { return _namesPool; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(NamesPool), "NamesPool cannot be null.");
                _namesPool = value;
            }
        }

        public string DisallowedLastNameSubstring
        {
            get { return _disallowedLastNameSubstring; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(DisallowedLastNameSubstring), "DisallowedLastNameSubstring cannot be null.");
                _disallowedLastNameSubstring = value;
            }
        }
    }

}
