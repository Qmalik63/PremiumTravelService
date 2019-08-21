using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
namespace PTS
{
    /// <summary>
    ///     Concrete TripState class to create a new trip.
    /// </summary>
    public class TripStateCreate : TripState
    {

        
        public TripStateCreate(TripContext context) :
            base(context, TripState.Status.Create)
        {
            TripContext.Trip = new Trip()
            {
                BookedOn = DateTime.Now,
                OrderId = DateTime.Now.Ticks,
                TripStateStatus = TripState.Status.Create
            };
        }

        private IReadOnlyList<TravelAgent> travelAgents = AgentList.GetList();

        private IReadOnlyList<Person> travellers = TravellerList.GetList();

        public override TripStateLoop.Status Execute()
        {

            int id = 0;
            int agentNumber;
            Console.WriteLine();
            Console.WriteLine("Please select the agent by entering the number corresponding to the agent");
            

            for(int x = 0; x < travelAgents.Count; x++)
            {
                Console.WriteLine($"{x + 1}: " + travelAgents[x].ToString());
            }

            
            //loops to handle user input
            var enterAgentNumber = true;
            while (enterAgentNumber)
            {
                string newAgentNumber = (Console.ReadLine() ?? "").Trim();

               
                if (Int32.TryParse(newAgentNumber, out agentNumber))
                {

                    if (agentNumber > travelAgents.Count  || agentNumber < 1)
                    {
                        Console.WriteLine("Please enter a valid number");
                        continue;
                    }
                    TripContext.Trip.TripAgent = travelAgents[agentNumber - 1];
                    Console.WriteLine($"Welcome {travelAgents[agentNumber -1].name}".ToUpper());
                    break;

                }

                Console.WriteLine("Please enter a valid number");

            }
            

            
            Console.WriteLine();
            Console.WriteLine("To view existing trips, enter [yes], to create a new trip hit the enter key");
            Console.WriteLine();

            var chooseExisting = true;
            while(chooseExisting)
            {
                string decision = (Console.ReadLine() ?? "").Trim();

                if(GoToExisting(decision))
                {
                    TripContext.ChangeState(new TripStateHandleExisting(TripContext));
                    return TripStateLoop.Status.Continue;
                }

                break;
            }

            Console.WriteLine();
            Console.WriteLine("*** NEW TRIP CREATED ***");

            Console.WriteLine(" Enter trip ID for the new trip");

            var enterTripID = true;
            while (enterTripID)
            {
                string newAmount = (Console.ReadLine() ?? "").Trim();

                //int payerNumber = Int32.Parse(Console.ReadLine());
                if (Int32.TryParse(newAmount, out id))
                {
                    TripContext.Trip.tripID = id;
                    break;

                }

                Console.WriteLine("Please enter a valid number");
                
            }



            Console.WriteLine("Please add travellers to the trip by entering the number corresponding to the person");
            Console.WriteLine();


            for (int x = 0; x <travellers.Count; x++)
            {
                Console.WriteLine($"{x + 1}: " + travellers[x].ToString());
            }

           
            Console.WriteLine();

            var selectTravellers = true;
            while (selectTravellers)
            {
                string newTraveller = (Console.ReadLine() ?? "").Trim();
                //int packSelect = Int32.Parse(newPackage)-1;
                
                if (Int32.TryParse(newTraveller, out int travelSelect))
                {
                    if(travelSelect > travellers.Count  || travelSelect < 1)
                    {
                        Console.WriteLine("Please enter a valid number");
                        continue;
                    }
                }
                if (ReturnLater(newTraveller)) return TripStateLoop.Status.Stop;
                if (ContinueEnteringDestinations(newTraveller))
                {
                    if (IsDestinationValid(newTraveller, travelSelect-1))
                    {
                        TripContext.Trip.selectedTravellers.Add(travellers[travelSelect - 1]);
                        Console.WriteLine($"- Added Traveller [{travellers[travelSelect-1].ToString()}]");
                    }
                }
                else
                {
                    //stop if we can change state
                     selectTravellers = !IsDestinationListValid();

                }
            }

            TripContext.ChangeState(new TripStateAddPackages(TripContext));
            return TripStateLoop.Status.Continue;
        }


        //methods for validating user input
        private bool IsDestinationValid(string newTraveller, int selector)
        {
            if (string.IsNullOrWhiteSpace(newTraveller))
            {
                Console.WriteLine("ERROR: You must enter a person");
                return false;
            }

            //var isDuplicate = TripContext.Trip.Destinations.Contains(newDestination);
            var isDuplicate = TripContext.Trip.selectedTravellers.Contains(travellers[selector]);

            if (isDuplicate) Console.WriteLine("ERROR: Unique travellers only!");
            return !isDuplicate;
        }

        private bool ContinueEnteringDestinations(string newTraveller)
        {
            var done = newTraveller.ToLower() == "done";
            if (done && TripContext.Trip.selectedTravellers.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("*FINISHED ENTERING TRAVELLERS: " +
                                  $"{TripContext.Trip.selectedTravellers.Count} entered *");
            }

            return !done;
        }

        private bool IsDestinationListValid()
        {
            if (TripContext.Trip.selectedTravellers.Count > 0) return true;
            Console.WriteLine("ERROR: At least ONE traveller is required");
            return false;
        }

    }
}