using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS
{
    /// <summary>
    /// Singleton to produce list of travellers
    /// </summary>
    sealed class TravellerList
    {
        private static readonly object Sync1 = new object();
        private static volatile List<Person> people;

        private TravellerList()
        {

        }

        //public List<Person> people;
        public static IReadOnlyList<Person> GetList()
        {
            if (people == null)
                lock (Sync1)
                    if (people == null)
                        LoadList();

            return people.AsReadOnly();
            
        }

        public static void LoadList()
        {
            people = new List<Person>();
            people.Add(new Person("Earl Lemongrab", "478-595-1227"));
            people.Add(new Person("Bobby Hill", "478-998-7958"));
            people.Add(new Person("Joseph Joestar", "478-1111-2341"));
            people.Add(new Person("Mr. Pickles", "478-697-7755"));
            people.Add(new Person("Rigby", "478-697-7999"));







        }
    }
}
