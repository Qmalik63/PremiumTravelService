using System;
namespace PTS
{
    /// <summary>
    ///     Concrete Cash Payment instance
    /// </summary>
    public class PaymentCash : Payment
    {
        public PaymentCash(decimal amount) : base(amount)
        {
        }

        public override string Describe()
        {
            return $"{base.Describe()} cash";
        }
    }
}