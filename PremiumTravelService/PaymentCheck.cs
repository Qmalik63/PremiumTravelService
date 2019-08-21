using System;
namespace PTS
{
    /// <summary>
    ///     Concrete Check Payment instance
    /// </summary>
    public class PaymentCheck : Payment
    {
        public PaymentCheck(decimal amount, int checkNumber) : base(amount)
        {
            CheckNumber = checkNumber;
        }

        public int CheckNumber { get; }

        public override string Describe()
        {
            return base.Describe() + $", check number {CheckNumber}";
        }
    }
}