using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS
{
    /// <summary>
    /// Singleton For Travel Agent List
    /// </summary>
    sealed class AgentList
    {
        
        private static readonly object Sync1 = new object();
        private static volatile List<TravelAgent> agents;

        private AgentList()
        {

        }

        //public List<Person> people;
        public static IReadOnlyList<TravelAgent> GetList()
        {
            if (agents == null)
                lock (Sync1)
                    if (agents == null)
                        LoadList();

            return agents.AsReadOnly();

        }

        public static void LoadList()
        {
            agents = new List<TravelAgent>();
            agents.Add(new TravelAgent("Princess Caroline", "478-595-8727"));
            agents.Add(new TravelAgent("Stewie Griffin", "478-998-4508"));
            

        }
    }
}
