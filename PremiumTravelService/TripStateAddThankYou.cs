using System;

namespace PTS
{
    /// <summary>
    ///     Concrete TripState class to add thank you note.
    ///     
    /// </summary>
    public class TripStateAddThankYou : TripState
    {
        public TripStateAddThankYou(TripContext context) :
            base(context, TripState.Status.AddThankYou)
        {
        }

        private bool IsThankYouValid(string thankYou)
        {
            if (string.IsNullOrWhiteSpace(thankYou))
            {
                Console.WriteLine("- ERROR: Thank You cannot be empty");
                return false;
            }

            if (thankYou.Length < 5)
            {
                Console.WriteLine("- ERROR: Thank you must be at least 5 characters");
                return false;
            }

            return true;
        }

        public override TripStateLoop.Status Execute()
        {
            Console.WriteLine(Environment.NewLine + "*** ADD THANK YOU ***");
            Console.WriteLine();
            Console.WriteLine("- COMMAND: [later] to return later or write thank you note (5 chars min)");

            var getThankYou = true;
            string thankYou = null;
            while (getThankYou)
            {
                thankYou = (Console.ReadLine() ?? "").Trim();

                //come back later?
                if (ReturnLater(thankYou)) return TripStateLoop.Status.Stop;

                //stop if we can change state
                getThankYou = !IsThankYouValid(thankYou);
            }

            TripContext.Trip.ThankYou = thankYou;
            TripContext.ChangeState(new TripStateComplete(TripContext));
            return TripStateLoop.Status.Continue;
        }
    }
}