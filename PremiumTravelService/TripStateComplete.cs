using System;

namespace PTS
{
    /// <summary>
    ///     Concrete TripState class to indicate Trip is now complete.
    ///     Once here, the state loop call should be stopped to avoid
    ///     infinite loop.
    /// </summary>
    public class TripStateComplete : TripState
    {
        public TripStateComplete(TripContext context) :
            base(context, TripState.Status.Complete)
        {
        }

        public override TripStateLoop.Status Execute()
        {
            Console.WriteLine(Environment.NewLine + "***COMPLETE - ITINERARY AVAILABLE ***");
            Console.WriteLine();

            //this is the end, so stop looping
            return TripStateLoop.Status.Stop;
        }
    }
}