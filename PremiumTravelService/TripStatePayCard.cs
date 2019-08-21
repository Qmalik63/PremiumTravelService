using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS
{
    /// <summary>
    /// Concrete TripState class to accept Payment
    /// </summary>
    public class TripStatePayCard : TripState
    {
        public TripStatePayCard(TripContext context) :
            base(context, TripState.Status.PayCard)
        {
        }

        public override TripStateLoop.Status Execute()
        {
            int cardNumber = 0;
            string expDate;
            decimal amount = 0;
            Console.WriteLine(Environment.NewLine + "*** ACCEPT CARD PAYMENT ***");

            Console.WriteLine("Enter Card Number or [later] to return later");

            var selectCardNumber = true;
            while (selectCardNumber)
            {
                string newCardNumber = (Console.ReadLine() ?? "").Trim();

                //int payerNumber = Int32.Parse(Console.ReadLine());
                if (Int32.TryParse(newCardNumber, out int number)) 
                {
                    cardNumber = number;
                    break;
                }
                else if (ReturnLater(newCardNumber)) return TripStateLoop.Status.Stop;

                else Console.WriteLine("Please enter a valid number");
                

            }

            Console.WriteLine("Enter card expiration date (mm/yy) or [later] to return later");

            var inputExpDate = true;
            while (inputExpDate)
            {
                string newExpDate = (Console.ReadLine() ?? "").Trim();

                //int payerNumber = Int32.Parse(Console.ReadLine());

                if (ReturnLater(newExpDate)) return TripStateLoop.Status.Stop;

                else expDate = newExpDate;
                break;


            }

            Console.WriteLine();
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
                    if(amount > TripContext.Trip.totalPrice)
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

            
            TripContext.Trip.Payment = new PaymentCard(cardNumber, amount, "02/21)");
            Console.WriteLine($"{TripContext.Trip.Payer} paid {TripContext.Trip.totalPrice} by card");

            
               

            TripContext.ChangeState(new TripStateAddThankYou(TripContext));
            return TripStateLoop.Status.Continue;
        }
    }
}
