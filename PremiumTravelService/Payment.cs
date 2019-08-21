using System;
namespace PTS
{
    /// <summary>
    ///     Abstract base class that holds Amount
    /// </summary>
    public abstract class Payment
    {
        protected Payment(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; }

        public virtual string Describe()
        {
            return $"Collected ${Amount}";
        }

        public override string ToString()
        {
            return Describe();
        }
    }
}