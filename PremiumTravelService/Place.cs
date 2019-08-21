using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS
{
    /// <summary>
    /// locations for packages
    /// </summary>
    public class Place
    {
        public Place(string place)
        {
            location = place;
        }

        public string location { get; }
    }
}
