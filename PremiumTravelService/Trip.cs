using System;
using System.Collections.Generic;

namespace PTS
{
    /// <summary>
    ///     Example Trip container
    /// </summary>
    public class Trip
    {
        public Trip()
        {
            TripStateStatus = TripState.Status.Create;
            Destinations = new List<string>();
            
        }

        /// <summary>
        ///     Holds status of Trip instance.
        ///     Do not arbitrarily change.
        ///     Must be managed by TripState machine.
        /// </summary>
        
       
        public TripState.Status TripStateStatus { get; set; }
        public decimal totalPrice { get; set; }
        public int tripID { get; set; }
        public TravelAgent TripAgent { get; set; }
        public long OrderId { get; set; }
        public DateTime BookedOn { get; set; }
        public List<string> Destinations { get; set; }
        public string ThankYou { get; set; }
        public Payment Payment { get; set; }
        public Person Payer { get; set; }
        public List<Person> selectedTravellers = new List<Person>();
        public List<Package> selectedPacks = new List<Package>();

        
    }
}