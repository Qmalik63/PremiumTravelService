using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS
{
    /// <summary>
  
    /// </summary>
    public class TravelAgent : Person
    {
        public TravelAgent(string newName, string phoneNumber) : base(newName, phoneNumber)
        {
            ////name = newName;
            ////mobilePhone = phoneNumber;
            
        }

        //public int agentID { get; }
        //public string name { get; }
        //public string mobilePhone { get; set; }
        //public List<TripContext> existingTrips { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        //public TripStateLoop.Status LoadTrips()
        //{
        //    Trip incompleteTrip = new Trip();
        //    incompleteTrip.TripStateStatus = TripState.Status.AddPackages;
        //    incompleteTrip.tripID = 129046;
        //    incompleteTrip.TripAgent = this;
        //    incompleteTrip.selectedTravellers.Add(new Person("Bojack H.", "478-691-9002"));
        //    incompleteTrip.selectedTravellers.Add(new Person("Mr. Peanutbutter", "478-691-8181"));

        //    TripContext context1 = new TripContext( incompleteTrip);


        //    Trip completeTrip = new Trip();
        //    completeTrip.TripStateStatus = TripState.Status.Complete;
        //    completeTrip.tripID = 19067;
        //    completeTrip.TripAgent = this;
        //    completeTrip.selectedTravellers.Add(new Person("Bojack H.", "478-691-9002"));
        //    completeTrip.selectedTravellers.Add(new Person("Mr. Peanutbutter", "478-691-8181"));

        //    completeTrip.selectedPacks.Add(new Package("LAX Airport", "Atlanta Airport", new DateTime(2019, 2, 25, 12, 0, 0), new DateTime(2019, 1, 20, 15, 0, 0), Package.TransportType.PrivateJet));
        //    completeTrip.Payer = completeTrip.selectedTravellers[0];
        //    completeTrip.Payment = new PaymentCash(completeTrip.totalPrice);
        //    completeTrip.ThankYou = "Thanks Bojack, you're the greatest";
        //    TripContext context2 = new TripContext(completeTrip);
        //    existingTrips.Add(context1);
        //    existingTrips.Add(context2);

        //    Console.WriteLine("Choose the number of the trip you wish to continue");

        //    for (int existingTripIndex = 0; existingTripIndex < existingTrips.Count; existingTripIndex++)
        //    {
        //        Console.WriteLine($"{existingTripIndex}. TripID:{existingTrips[existingTripIndex].Trip.tripID}, Status: {existingTrips[existingTripIndex].Trip.TripStateStatus}");
        //    }

        //    int tripSelector = 0;
            
            

        //    //loop to handle user input
        //    var selectTrip = true;
        //    while (selectTrip)
        //    {
        //        string newTrip = (Console.ReadLine() ?? "").Trim();


        //        if (Int32.TryParse(newTrip, out tripSelector))
        //        {

        //            if (tripSelector > existingTrips.Count || tripSelector < 1)
        //            {
        //                Console.WriteLine("Please enter a valid number");
        //                continue;
        //            }
        //            existingTrips[tripSelector - 1].Execute();
                    
        //            //TripContext.Trip.TripAgent = travelAgents[agentNumber - 1];
        //            //Console.WriteLine($"Welcome {travelAgents[agentNumber - 1].name}".ToUpper());
        //            break;

        //        }

        //        Console.WriteLine("Please enter a valid number");

        //    }

            
            


        //}

    }
}
