using System;

namespace PTS
{
    /// <summary>
    ///     Booking detail itinerary decorator
    /// </summary>
    public class ItineraryAppendBookingDetails : ItineraryDecorator
    {
        public ItineraryAppendBookingDetails(IItineraryComponent componentToDecorate) : base(componentToDecorate)
        {
        }

        string empty;
        public override string Output()
        {
            var toOutput = base.Output();
            toOutput += $"Order # : {Trip.OrderId}" + Environment.NewLine;
            toOutput += $"Booked  : {Trip.BookedOn}" + Environment.NewLine;
            toOutput += $"Payment : {Trip.Payment}| Paid by: {Trip.Payer}" + Environment.NewLine;
            toOutput += Environment.NewLine;
            toOutput += "Travellers:" + Environment.NewLine;
            
            toOutput += ListOfTravellers(Trip, empty);
            
            return toOutput;
        }

        protected string ListOfTravellers(Trip trip, string test)
        {
            
            foreach(var x in trip.selectedTravellers)
            {
                test += x.ToString() + "\n";
            }
            return test;
        }
    }
}