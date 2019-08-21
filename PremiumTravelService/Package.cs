using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS
{
    /// <summary>
    /// Concrete Class for packages to be reserved in a trip
    /// </summary>
    public class Package
    {
        public Package(string startLocation, string endLocation, DateTime start, DateTime end, TransportType vehicle)
        {
            currentLocation = startLocation;
            destination = endLocation;
            departure = start;
            arrival = end;
            price = GetPrice(this);


            Vehicle = vehicle;
        }


        public DateTime departure { get; set; }
        public DateTime arrival { get; set; }
        public string destination { get; set; }
        public string currentLocation { get; set; }
        public decimal price { get; set; }
        public TransportType Vehicle { get; }

        

        /// <summary>
        /// Formula for calculating the price of packages
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        public decimal GetPrice(Package package)
        {

            TimeSpan ts = package.departure - package.arrival;
            int length = ts.Hours;


            //ouble length = ts.TotalHours;
            switch (package.Vehicle)
            {
                case TransportType.Helicopter:
                    {
                        return (decimal)1000.55 * length;
                    }

                case TransportType.Limousine:
                    {
                        return (decimal)550.55 * length;
                    }

                case TransportType.PrivateJet:
                    {
                        return (decimal)1500.59 * length;
                    }

                case TransportType.Yacht:
                    {
                        return (decimal)1250.504 * length;
                    }

                default:
                    throw new NotSupportedException($"{package.Vehicle} is not available");

            }
        }

        public override string ToString()
        {
            return $"{Vehicle} from {currentLocation} on {departure.ToString("MM/dd/yyyy htt")} to {destination} on {arrival.ToString("MM/dd/yyyy htt")} ";
        }

        public enum TransportType
        {
            Helicopter,
            Limousine,
            Yacht,
            PrivateJet


        }
    }

   

    
}
