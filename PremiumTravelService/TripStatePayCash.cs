using System;

namespace PTS
{
    /// <summary>
    ///     Concrete TripState class to accept cash payment.
    ///     
    /// </summary>
    public class TripStatePayCash : TripState
    {
        public TripStatePayCash(TripContext context) :
            base(context, TripState.Status.PayCash)
        {
        }

        public override TripStateLoop.Status Execute()
        {
            decimal amount = 0;
            Console.WriteLine(Environment.NewLine + "*** ACCEPT CASH PAYMENT ***");
            Console.WriteLine();
            Console.WriteLine("- COMMAND: [later] to return later or amount");
            Console.WriteLine();

            Console.WriteLine($"The total amount for the trip is: ${TripContext.Trip.totalPrice}");
            Console.WriteLine("- Enter amount or [later] to return later");
            Console.WriteLine();


            // loops to handle user input
            var enterAmount = true;
            while (enterAmount)
            {
                string newAmount = (Console.ReadLine() ?? "").Trim();

                //int payerNumber = Int32.Parse(Console.ReadLine());
                if (Decimal.TryParse(newAmount, out amount))
                {
                    if (amount > TripContext.Trip.totalPrice)
                    {
                        Console.WriteLine("You are overpaying, we don't need your pity, please re-enter amount");
                        continue;
                    }

                    if (amount < TripContext.Trip.totalPrice)
                    {
                        Console.WriteLine("You are underpaying, please, we are struggling, re-enter amount");
                        continue;

                    }


                }
                else if (ReturnLater(newAmount)) return TripStateLoop.Status.Stop;

                

                else Console.WriteLine("Please enter a valid number");

                break;

            }

            
            TripContext.Trip.Payment = new PaymentCash(amount);
            Console.WriteLine($"{TripContext.Trip.Payer} paid {TripContext.Trip.totalPrice} by cash");

            //change state when finished
            TripContext.ChangeState(new TripStateAddThankYou(TripContext));
            return TripStateLoop.Status.Continue;
        }
    }
}