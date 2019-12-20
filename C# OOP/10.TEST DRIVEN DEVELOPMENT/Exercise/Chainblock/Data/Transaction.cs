namespace Chainblock.Data
{
    using Contracts;
    using System;

    public class Transaction : ITransaction
    {
        public Transaction(int id, string status, string from, string to, double amount)
        {
            Id = id;
            Status = (TransactionStatus)Enum.Parse(typeof(TransactionStatus), status);
            From = from;
            To = to;
            Amount = amount;
        }

        public int Id { get; set; }
        public TransactionStatus Status { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Amount { get; set; }
    }
}
