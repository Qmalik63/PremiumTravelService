using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS
{
    /// <summary>
    /// Base class for Travel Agents and Travellers
    /// </summary>
    public class Person
    {
        public Person(string newName, string phoneNumber)
        {
            name = newName;
            mobilePhone = phoneNumber;
        }

        public string name { get; }
        public string mobilePhone { get; set; }

        public override string ToString()
        {
            return $"{name}, Phone: {mobilePhone}";
        }
    }

    
}
