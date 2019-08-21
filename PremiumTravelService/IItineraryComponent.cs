using System;
namespace PTS
{
    /// <summary>
    ///     Interface implemented by all Itinerary decorators
    /// </summary>
    public interface IItineraryComponent
    {
        Trip Trip { get; }
        string Output();
    }
}