using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS
{
    /// <summary>
    /// Singleton for packages
    /// </summary>
    sealed class PackageList
    {
        private static readonly object Sync1 = new object();
        private static volatile List<Package> packages;

        private PackageList()
        {

        }

        //public List<Person> people;
        public static IReadOnlyList<Package> GetList()
        {
            if (packages == null)
                lock (Sync1)
                    if (packages == null)
                        LoadList();

            return packages.AsReadOnly();

        }

        public static void LoadList()
        {
            packages = new List<Package>();
            packages.Add(new Package("Pickles Estate","Atlanta Airport",new DateTime(2019,1,20,3,0,0), new DateTime(2019, 1, 20, 5, 0, 0), Package.TransportType.Limousine));
            packages.Add(new Package("Atlanta Airport", "Bora Bora Airport", new DateTime(2019, 1, 20, 5, 0, 0), new DateTime(2019, 1, 20, 17, 0, 0), Package.TransportType.PrivateJet));
            packages.Add(new Package("Bora Bora Airport", "BB Luxury Resort", new DateTime(2019, 1, 20, 17, 0, 0), new DateTime(2019, 1, 20, 22, 0, 0), Package.TransportType.Yacht));
            packages.Add(new Package("BB Luxury Resort", "Honolulu Airport", new DateTime(2019, 1, 25, 12, 0, 0), new DateTime(2019, 1, 25, 18, 0, 0), Package.TransportType.Helicopter));
            packages.Add(new Package("Honolulu Airport", "Atlanta Airport", new DateTime(2019, 2, 5, 10, 0, 0), new DateTime(2019, 1, 20, 18, 0, 0), Package.TransportType.PrivateJet));







        }
    }
}
