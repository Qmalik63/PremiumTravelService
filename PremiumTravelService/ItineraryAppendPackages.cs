using System;

namespace PTS
{
    /// <summary>
    ///     Destinations itinerary decorator
    /// </summary>
    public class ItineraryAppendPackages : ItineraryDecorator
    {
        public ItineraryAppendPackages(IItineraryComponent componentToDecorate) : base(componentToDecorate)
        {
        }

        public override string Output()
        {
            var toOutput = base.Output();
            toOutput += "PACKAGES" + Environment.NewLine;
            toOutput += Environment.NewLine;
            for (var packs = 0; packs < Trip.selectedPacks.Count; packs++)
                toOutput += $"{packs + 1,2}. {Trip.selectedPacks[packs]}-- Price: ${Trip.selectedPacks[packs].price}" + Environment.NewLine;
            return toOutput;
        }
    }
}