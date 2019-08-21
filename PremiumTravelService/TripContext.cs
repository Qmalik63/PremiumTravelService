using System.Diagnostics;

namespace PTS
{
    /// <summary>
    ///     Context object that holds the current
    ///     concrete trip state instance. Access to the
    ///     Trip instance is also here. Concrete trip
    ///     states use TripContext to change state
    ///     and access Trip.
    /// </summary>
    public class TripContext
    {
        public TripContext()
        {
            TripState = new TripStateCreate(this);
        }

        /// <summary>
        ///     Uses TripContextStateFactory to inject context
        ///     object with correct concrete TripState object
        ///     using the TripStateStatus enum in Trip instance
        /// </summary>
        /// <param name="trip"></param>
        public TripContext(Trip trip)
        {
            Debug.Assert(trip != null, "trip cannot be null");
            Trip = trip;
            TripState = TripContextStateFactory.Get(this);
        }

        public Trip Trip { get; set; }

        public TripState TripState { get; private set; }

        /// <summary>
        ///     Changes state to another state.
        ///     Should not be used outside of the
        ///     TripState machine.
        /// </summary>
        /// <param name="newState"></param>
        public void ChangeState(TripState newState)
        {
            TripState = newState;
        }

        /// <summary>
        ///     Executes the current concrete TripState
        ///     instance to control specific behavior
        ///     related to the current state.
        /// </summary>
        /// <returns></returns>
        public TripStateLoop.Status Execute()
        {
            return TripState.Execute();
        }
    }
}