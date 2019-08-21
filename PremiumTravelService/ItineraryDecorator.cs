namespace PTS
{
    /// <summary>
    ///     Abstract itinerary decorator.
    ///     Holds reference to previous decorator
    ///     component in decorator chain and provides
    ///     base.Output call to access private _componentToDecorate
    /// </summary>
    public abstract class ItineraryDecorator : IItineraryComponent
    {
        private readonly IItineraryComponent _componentToDecorate;

        protected ItineraryDecorator(IItineraryComponent componentToDecorate)
        {
            _componentToDecorate = componentToDecorate;
        }

        public Trip Trip => _componentToDecorate.Trip;

        public virtual string Output()
        {
            return _componentToDecorate.Output();
        }
    }
}