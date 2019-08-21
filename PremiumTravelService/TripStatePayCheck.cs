using System;

namespace PTS
{
    /// <summary>
    ///     Concrete TripState class to accept check payment.
    ///     
    /// </summary>
    public class TripStatePayCheck : TripState
    {
        public TripStatePayCheck(TripContext context) :
            base(context, TripState.Status.PayCheck)
        {
        }

        public override TripStateLoop.Status Execute()
        {
            decimal amount = 0; ;
            int checkNumber = 0;
            Console.WriteLine(Environment.NewLine + "*** ACCEPT CHECK PAYMENT ***");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Enter Check Number or [later] to return later");


            // Loops to handle user input
            var inputCheckNumber = true;
            while (inputCheckNumber)
            {
                string newCheckNumber = (Console.ReadLine() ?? "").Trim();

                //int payerNumber = Int32.Parse(Console.ReadLine());
                if (Int32.TryParse(newCheckNumber, out int number))
                {
                    checkNumber = number;
                    break;
                }
                else if (ReturnLater(newCheckNumber)) return TripStateLoop.Status.Stop;

                else Console.WriteLine("Please enter a valid number");


            }


            Console.WriteLine($"The total amount for the trip is: ${TripContext.Trip.totalPrice}");
            Console.WriteLine("- Enter amount or [later] to return later");
            Console.WriteLine();

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

            
            TripContext.Trip.Payment = new PaymentCheck(amount, checkNumber);
            Console.WriteLine($"{TripContext.Trip.Payer} paid {TripContext.Trip.totalPrice} by check");



            //change state when finished
            TripContext.ChangeState(new TripStateAddThankYou(TripContext));
            return TripStateLoop.Status.Continue;
        }
    }
    
}