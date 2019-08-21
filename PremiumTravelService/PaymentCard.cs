using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS
{
    /// <summary>
    /// concrete card payment
    /// </summary>
    public class PaymentCard : Payment
    {
        public PaymentCard(int number, decimal amount, string date) : base(amount)
        {
            cardNumber = number;
            expDate = date;
        }

        public int cardNumber { get; }
        public string expDate { get; }

        public override string Describe()
        {
            return base.Describe() + $", card number {cardNumber}";
        }
    }
}
