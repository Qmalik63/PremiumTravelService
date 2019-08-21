using System;

namespace PTS
{
    internal class StateMachineDemo
    {
        private static void Main(string[] args)
        {
            //state loop will handle traversing through
            //the various states until the user
            //decides to return later (exit state loop with trip 
            //in an incomplete state) OR the trip is complete.
            var tripStateLoop = new TripStateLoop();
            var trip = tripStateLoop.Execute();

            while (true)
            {
                ShowItinerary(trip);

                //this loop simulates loading a trip from
                //storage and passing it back into the trip state loop
                //at the correct state to continue adding data
                //or showing the final state (itinerary)
                Console.WriteLine(
                    Environment.NewLine +
                    "Simulate trip reload to correct state? [yes]");

                if ((Console.ReadLine() ?? "").ToLower().Trim() == "yes")
                    tripStateLoop.Execute(trip);
                else
                    break;
            }
        }

        /// <summary>
        ///     Displays itinerary, if possible
        /// </summary>
        /// <param name="trip"></param>
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