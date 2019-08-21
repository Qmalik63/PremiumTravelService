using System;

namespace PTS
{
    /// <summary>
    ///     Append thank you note itinerary decorator
    /// </summary>
    public class ItineraryAppendSeparator : ItineraryDecorator
    {
        public ItineraryAppendSeparator(IItineraryComponent componentToDecorate) : base(componentToDecorate)
        {
        }

        public override string Output()
        {
            var toOutput = base.Output();
            toOutput += Environment.NewLine;
            toOutput += "-------------------------------------------------------" + Environment.NewLine;
            toOutput += Environment.NewLine;
            return toOutput;
        }
    }
}