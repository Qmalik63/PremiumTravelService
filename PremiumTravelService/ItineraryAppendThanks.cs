using System;

namespace PTS
{
    /// <summary>
    ///     Section separator itinerary decorator
    /// </summary>
    public class ItineraryAppendThanks : ItineraryDecorator
    {
        public ItineraryAppendThanks(IItineraryComponent componentToDecorate) : base(componentToDecorate)
        {
        }

        public override string Output()
        {
            var toOutput = base.Output();
            toOutput += "THANK YOU" + Environment.NewLine;
            toOutput += Environment.NewLine;
            toOutput += Trip.ThankYou + Environment.NewLine;
            return toOutput;
        }
    }
}