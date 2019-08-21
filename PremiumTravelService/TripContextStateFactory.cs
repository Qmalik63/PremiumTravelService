using System;
using System.Diagnostics;

namespace PTS
{
    /// <summary>
    ///     Static factory to set TripContext to the appropriate concrete
    ///     TripState instance using the Trip.TripStateStatus enum.
    /// </summary>
    public class TripContextStateFactory
    {
        public static TripState Get(TripContext context)
        {
            Debug.Assert(context != null);
            Debug.Assert(context.Trip != null);

            var tripStateStatus = context.Trip.TripStateStatus;

            switch (tripStateStatus)
            {
                case TripState.Status.Create:
                    return new TripStateCreate(context);

                case TripState.Status.AddPackages:
                    return new TripStateAddPackages(context);

                case TripState.Status.ChoosePaymentType:
                    return new TripStateChoosePaymentType(context);

                case TripState.Status.AddThankYou:
                    return new TripStateAddThankYou(context);

                case TripState.Status.Complete:
                    return new TripStateComplete(context);

                default:
                    throw new NotSupportedException($"{tripStateStatus} is an invalid state");
            }
        }
    }
}