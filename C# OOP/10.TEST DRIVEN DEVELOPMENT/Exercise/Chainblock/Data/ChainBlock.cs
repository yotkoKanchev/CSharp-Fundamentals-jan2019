namespace Chainblock.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Chainblock : IChainblock
    {
        private List<ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new List<ITransaction>();
        }

        public void Add(ITransaction transaction)
        {
            this.transactions.Add(transaction);
        }

        public bool Contains(ITransaction transaction)
        {
            return this.transactions.Any(t => t.Id == transaction.Id);
        }

        public bool Contains(int id)
        {
            return this.transactions.Any(t => t.Id == id);
        }

        public int Count => this.transactions.Count;

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            var transaction = this.transactions.FirstOrDefault(t => t.Id == id);

            if (transaction == null)
            {
                throw new ArgumentException($"Id {id} does not exists");
            }

            transaction.Status = newStatus;
        }

        public void RemoveTransactionById(int id)
        {
            var transaction = this.transactions.FirstOrDefault(t => t.Id == id);

            if (transaction == null)
            {
                throw new InvalidOperationException($"Id {id} does not exists");
            }

            this.transactions.Remove(transaction);
        }

        public ITransaction GetById(int id)
        {
            var transaction = this.transactions.FirstOrDefault(t => t.Id == id);

            if (transaction == null)
            {
                throw new InvalidOperationException($"Id {id} does not exists");
            }

            return transaction;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            var resultTransactions = this.transactions
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount)
                .ToList();

            if (resultTransactions.Count == 0)
            {
                throw new InvalidOperationException($"No transactions with Status {status.ToString()}");
            }

            return resultTransactions;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var senders = this.transactions
                 .Where(t => t.Status == status)
                 .OrderByDescending(t => t.Amount)
                 .Select(t => t.From)
                 .ToList();

            if (senders.Count == 0)
            {
                throw new InvalidOperationException($"No senders with Status {status.ToString()}");
            }

            return senders;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var recievers = this.transactions
                 .Where(t => t.Status == status)
                 .OrderByDescending(t => t.Amount)
                 .Select(t => t.To)
                 .ToList();

            if (recievers.Count == 0)
            {
                throw new InvalidOperationException($"No recievers with Status {status.ToString()}");
            }

            return recievers;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var resultTransactions = this.transactions
                .Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount)
                .ToList();

            if (resultTransactions.Count == 0)
            {
                throw new InvalidOperationException($"No transactions with Sender {sender}");
            }

            return resultTransactions;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var resultTransactions = this.transactions
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            if (resultTransactions.Count == 0)
            {
                throw new InvalidOperationException($"No transactions with Reciever {receiver}");
            }

            return resultTransactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(
            TransactionStatus status, double amount)
        {
            var resultTransactions = this.transactions
                .Where(t => t.Status == status)
                .Where(t => t.Amount <= amount)
                .OrderByDescending(t => t.Amount)
                .ToList();

            return resultTransactions;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(
            string sender, double amount)
        {
            var resultTransactions = this.transactions
                .Where(t => t.From == sender)
                .Where(t => t.Amount > amount)
                .OrderByDescending(t => t.Amount)
                .ToList();

            if (resultTransactions.Count == 0)
            {
                throw new InvalidOperationException(
                    $"No transactions with Sender {sender} and amount more then {amount}");
            }

            return resultTransactions;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var resultTransactions = this.transactions
                .Where(t => t.To == receiver)
                .Where(t => t.Amount >= lo && t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            if (resultTransactions.Count == 0)
            {
                throw new InvalidOperationException(
                    $"No transactions with Reciever {receiver} and amount in range [{lo}, {hi}]");
            }

            return resultTransactions;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            var resultTransactions = this.transactions
                .Where(t => t.Amount >= lo && t.Amount <= hi)
                .ToList();

            return resultTransactions;
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            for (int i = 0; i < this.transactions.Count - 1; i++)
            {
                yield return this.transactions[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
