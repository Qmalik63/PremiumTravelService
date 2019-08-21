using System;
using System.Linq;
using System.Collections.Generic;
namespace PTS
{
    /// <summary>
    ///     Concrete TripState class to add destinations.
    ///     
    /// </summary>
    public class TripStateAddPackages : TripState
    {
        public TripStateAddPackages(TripContext context) :
            base(context, TripState.Status.AddPackages)
        {
        }

        IReadOnlyList<Package> premadePacks = PackageList.GetList();
        

        private bool IsDestinationListValid()
        {
            if (TripContext.Trip.selectedPacks.Count > 0) return true;
            Console.WriteLine("ERROR: At least ONE destination is required");
            return false;
        }

        private bool IsDestinationValid(string newDestination, int selector)
        {
            if (string.IsNullOrWhiteSpace(newDestination))
            {
                Console.WriteLine("ERROR: Blank packages are prohibited!");
                return false;
            }

            
            var isDuplicate = TripContext.Trip.selectedPacks.Contains (premadePacks[selector]);

            if (isDuplicate) Console.WriteLine("ERROR: Unique packages only!");
            return !isDuplicate;
        }

        private bool ContinueEnteringDestinations(string newDestination)
        {
            var done = newDestination.ToLower() == "done";
            if (done && TripContext.Trip.Destinations.Any())
            {
                Console.WriteLine();
                Console.WriteLine("*** DESTINATIONS FINISHED: " +
                                  $"{TripContext.Trip.selectedPacks.Count} entered ***");
            }

            return !done;
        }

        private void ShowCurrentDestinations()
        {
            if (!TripContext.Trip.Destinations.Any()) return;

            Console.WriteLine($"- Currently {TripContext.Trip.Destinations.Count} in trip");
            for (var dest = 0; dest < TripContext.Trip.Destinations.Count; dest++)
                Console.WriteLine($"  {dest + 1}. {TripContext.Trip.Destinations[dest]}");
            Console.WriteLine();
        }

        public override TripStateLoop.Status Execute()
        {
            Console.WriteLine(Environment.NewLine + "*** ADD PACKAGES ***");
            Console.WriteLine();

          


            for (int x = 0; x < premadePacks.Count; x++)
            {
                Console.WriteLine($"{x + 1}: " + premadePacks[x].ToString());
                Console.WriteLine();

            }

        


            ShowCurrentDestinations();
            Console.WriteLine(
                "- COMMAND: [later] to return later, [done] to finish destinations, or enter number of package");

            var selectPackages = true;
            while (selectPackages)
            {
                string newPackage = (Console.ReadLine() ?? "").Trim();
                if (ReturnLater(newPackage)) return TripStateLoop.Status.Stop;
                int packSelect;
                if(Int32.TryParse(newPackage, out packSelect  ))
                {
                    if(packSelect > premadePacks.Count  || packSelect < 1)
                    {
                        Console.WriteLine("Please enter a valid number");
                        continue;
                    }
                }


                //come back later?
                //if (ReturnLater(newPackage)) return TripStateLoop.Status.Stop;

                else
                {
                    Console.WriteLine("Please enter a valid number");
                    
                }
                //check unique and continue entering
                if (ContinueEnteringDestinations(newPackage))
                {
                    if (IsDestinationValid(newPackage, packSelect - 1))
                    {
                        TripContext.Trip.selectedPacks.Add(premadePacks[packSelect - 1]);
                        Console.WriteLine($"- Added Package [{premadePacks[packSelect-1].ToString()}]");
                    }
                }
                else
                {
                    //stop if we can change state
                    selectPackages = !IsDestinationListValid();
                }
            }

            TripContext.ChangeState(new TripStateChoosePaymentType(TripContext));
            return TripStateLoop.Status.Continue;
        }
    }
}