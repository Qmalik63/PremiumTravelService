using System;

namespace PTS
{
    /// <summary>
    ///     Abstract base class for TripState machine.
    ///     Holds reference to TripContext
    /// </summary>
    public abstract class TripState
    {
        protected TripState(TripContext context, Status tripStateStatus)
        {
            TripContext = context;

            if (TripContext.Trip != null) TripContext.Trip.TripStateStatus = tripStateStatus;
        }

        protected TripContext TripContext { get; set; }

        public abstract TripStateLoop.Status Execute();

        /// <summary>
        ///     Return later helper... used in a few places,
        ///     so moved to base class to eliminate redundant code
        /// </summary>
        /// <returns></returns>
        protected bool ReturnLater(string answer)
        {
            var returnLater = answer.ToLower() == "later";
            if (returnLater)
            {
                Console.WriteLine();
                Console.WriteLine("*** RETURN LATER TO FINISH ***");
            }

            return returnLater;
        }

        protected bool GoToExisting(string answer)
        {
            var returnLater = answer.ToLower() == "yes";
            if (returnLater)
            {
                Console.WriteLine();
                Console.WriteLine("*** EXISTING TRIPS ***");
            }

            return returnLater;
        }

        protected bool ContinueToCreate(string answer)
        {
            var returnLater = answer.ToLower() == "continue";
            if (returnLater)
            {
                Console.WriteLine();
                Console.WriteLine("*** RETURN LATER TO FINISH ***");
            }

            return returnLater;
        }
        /// <summary>
        ///     states a trip can be in.
        ///     create = first state
        ///     complete = last state
        /// </summary>
        public enum Status
        {
            Create,
            AddPackages,
            ChoosePaymentType,
            PayCash,
            PayCheck,
            PayCard,
            AddThankYou,
            HandleExisting,
            Complete
        }

        //Create, then
        //AddDestinations, then
        //ChoosePaymentType
        //   if cash, then PayCash, then
        //   if check, then PayCheck, then
        //AddThankYou, then
        //Complete
        //
        //Itinerary cannot be generated until TripStateStatus = Complete
        //When state = Complete, the Trip object has been verified to be
        //complete and all validation requirements fulfilled.
    }
}