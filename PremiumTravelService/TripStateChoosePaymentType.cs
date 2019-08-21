using System;

namespace PTS
{
    /// <summary>
    ///     Concrete TripState class to choose payment type.
    ///     Changes state conditionally.
    /// </summary>
    public class TripStateChoosePaymentType : TripState
    {
        public TripStateChoosePaymentType(TripContext context) :
            base(context, TripState.Status.ChoosePaymentType)
        {
        }


        public override TripStateLoop.Status Execute()
        {
            

            for(int x = 0; x < TripContext.Trip.selectedPacks.Count; x++)
            {
                TripContext.Trip.totalPrice += Math.Abs(TripContext.Trip.selectedPacks[x].price);
            }

            Console.WriteLine($"THE TOTAL PRICE OF THE TRIP IS: ${TripContext.Trip.totalPrice}");
            Console.WriteLine();
            Console.WriteLine("COMMAND: ENTER THE NUMBER OF THE TRAVELLER WHO WILL BE PAYING OR [later] TO RETURN LATER:");
            Console.WriteLine();
        
               

            for (int x = 0; x < TripContext.Trip.selectedTravellers.Count; x++)
            {
                Console.WriteLine($"{x + 1}: " + TripContext.Trip.selectedTravellers[x].ToString());
            }

            var selectPayer = true;
            while (selectPayer)
            {
                string newPayer = (Console.ReadLine() ?? "").Trim();

                //int payerNumber = Int32.Parse(Console.ReadLine());
                if (Int32.TryParse(newPayer, out int payerNumber) && (payerNumber > 0 &&
                    payerNumber < TripContext.Trip.selectedTravellers.Count+1))
                {
                    Console.WriteLine($"Payer = { TripContext.Trip.selectedTravellers[payerNumber - 1].ToString() }");
                    TripContext.Trip.Payer = TripContext.Trip.selectedTravellers[payerNumber - 1];
                    break;
                }
                else if (ReturnLater(newPayer)) return TripStateLoop.Status.Stop;

                else Console.WriteLine("Please enter a valid number");

            }
           
            Console.WriteLine(Environment.NewLine + "*** CHOOSE PAYMENT TYPE ***");
            Console.WriteLine();
            Console.WriteLine("- COMMAND: [later] to return later, [cash] or [check] or [card]");

            while (true)
            {
                var paymentType = (Console.ReadLine() ?? "").Trim();
                if (ReturnLater(paymentType)) return TripStateLoop.Status.Stop; //exit loop and method

                //empty entry does nothing
                if (string.IsNullOrWhiteSpace(paymentType)) continue;

                if (paymentType == "cash")
                {
                    TripContext.ChangeState(new TripStatePayCash(TripContext));
                    return TripStateLoop.Status.Continue;
                }

                if (paymentType == "check")
                {
                    TripContext.ChangeState(new TripStatePayCheck(TripContext));
                    return TripStateLoop.Status.Continue;
                }

                if (paymentType == "card")
                {
                    TripContext.ChangeState(new TripStatePayCard(TripContext));
                    return TripStateLoop.Status.Continue;
                }

                Console.WriteLine("- ERROR: [later], [cash], [check], or [card]");
            }
        }
    }
}