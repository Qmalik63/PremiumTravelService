using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS
{
    /// <summary>
    /// Concrete Trip State for handling existing trips
    /// </summary>
    public class TripStateHandleExisting: TripState
    {

        public TripStateHandleExisting(TripContext context)  : base(context, TripState.Status.HandleExisting )
            
        {
            
        }

        
        //Hardcoded existing Trips
        public override TripStateLoop.Status Execute()
        {
            List<TripContext> existingTrips = new List<TripContext>();
            var tripStateLoop = new TripStateLoop();
            //TripContext.Trip.TripAgent.LoadTrips();
            //public TripStateLoop.Status LoadTrips()
            {
                Trip incompleteTrip = new Trip();
                incompleteTrip.TripStateStatus = TripState.Status.AddPackages;
                incompleteTrip.tripID = 129046;
                incompleteTrip.BookedOn = DateTime.Now;
                incompleteTrip.OrderId = DateTime.Now.Ticks;
                incompleteTrip.TripAgent = TripContext.Trip.TripAgent;
                incompleteTrip.selectedTravellers.Add(new Person("Bojack H.", "478-691-9002"));
                incompleteTrip.selectedTravellers.Add(new Person("Mr. Peanutbutter", "478-691-8181"));

                TripContext context1 = new TripContext(incompleteTrip);

                
                Trip completeTrip = new Trip();
                completeTrip.TripStateStatus = TripState.Status.Complete;
                completeTrip.tripID = 19067;
                completeTrip.TripAgent = TripContext.Trip.TripAgent;
                completeTrip.selectedTravellers.Add(new Person("Bojack H.", "478-691-9002"));
                completeTrip.selectedTravellers.Add(new Person("Mr. Peanutbutter", "478-691-8181"));
                completeTrip.BookedOn = DateTime.Now;
                completeTrip.OrderId = DateTime.Now.Ticks;

                completeTrip.selectedPacks.Add(new Package("LAX Airport", "Atlanta Airport", new DateTime(2019, 2, 25, 12, 0, 0), new DateTime(2019, 1, 20, 15, 0, 0), Package.TransportType.PrivateJet));
                completeTrip.Payer = completeTrip.selectedTravellers[0];
                completeTrip.totalPrice = completeTrip.selectedPacks[0].price;
                completeTrip.Payment = new PaymentCash(completeTrip.totalPrice);
                completeTrip.ThankYou = "Thanks Bojack, you're the greatest";
                TripContext context2 = new TripContext(completeTrip);
                existingTrips.Add(context1);
                existingTrips.Add(context2);

                Console.WriteLine("Choose the number of the trip you wish to continue");

                for (int existingTripIndex = 0; existingTripIndex < existingTrips.Count; existingTripIndex++)
                {
                    Console.WriteLine($"{existingTripIndex+1}. TripID:{existingTrips[existingTripIndex].Trip.tripID}, Status: {existingTrips[existingTripIndex].Trip.TripStateStatus}");
                }

                int tripSelector = 0;



                //loop to handle user input
                var selectTrip = true;
                while (selectTrip)
                {
                    string newTrip = (Console.ReadLine() ?? "").Trim();


                    if (Int32.TryParse(newTrip, out tripSelector))
                    {

                        if (tripSelector > existingTrips.Count || tripSelector < 1)
                        {
                            Console.WriteLine("Please enter a valid number");
                            continue;
                        }
                        //existingTrips[tripSelector - 1].Execute();

                        var existingTrip =tripStateLoop.Execute(existingTrips[tripSelector - 1].Trip);
                        while (true)
                        {
                            ShowItinerary(existingTrip);

                            
                            Console.WriteLine(
                                Environment.NewLine +
                                "Simulate trip reload to correct state? [yes]");

                            if ((Console.ReadLine() ?? "").ToLower().Trim() == "yes")
                                tripStateLoop.Execute(existingTrip);
                            else
                                break;
                        }

                        return TripStateLoop.Status.Continue;
                        
                       
                        
                    }

                    Console.WriteLine("Please enter a valid number");

                }
                
                return TripStateLoop.Status.Continue;

                



            }
        }

        // Method from StateMachineDemo to produce itenerary of a trip if possible
        private static void ShowItinerary(Trip trip)
        {
            if (ItineraryFactory.TripCanProduceItinerary(trip))
            {
                Console.WriteLine("Show itinerary? [yes]");
                if ((Console.ReadLine() ?? "").Trim().ToLower() != "yes") return;

                var itinerary = ItineraryFactory.Get(trip);
                Console.WriteLine(itinerary);
                return;
            }

            Console.WriteLine($"Trip {trip.OrderId} is not complete - cannot produce itinerary yet");
            Console.WriteLine($"Trip {trip.OrderId} state = {trip.TripStateStatus}");
            Console.WriteLine();
        }
    }
    
    
    
}
