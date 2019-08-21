namespace PTS
{
    /// <summary>
    ///     Base itinerary generator component that
    ///     will be decorated by additional IItineraryComponent
    ///     concrete classes
    /// </summary>
    public class Itinerary : IItineraryComponent
    {
        public Itinerary(Trip trip)
        {
            Trip = trip;
        }

        public Trip Trip { get; }

        public virtual string Output()
        {
            //base itinerary outputs nothing - could, but doesn't in this case
            //so it can delegate all responsibilities to decorators
            //all this class really does is hold the trip instance
            return string.Empty;
        }
    }
}