namespace Chainblock.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Contracts;
    using Data;
    using System.Linq;

    public class ChainblockTests
    {
        private Chainblock chainblock;
        private Transaction transaction;

        [SetUp]
        public void Setup()
        {
            this.chainblock = new Chainblock();
            this.transaction = new Transaction(1, "Successfull", "Pesho", "Gosho", 2000);
        }

        [Test]
        public void Constructor_ShouldInitializeChainblockWithAnEmptyListOfTransactions()
        {
            Assert.AreEqual(0, chainblock.Count);
        }

        [Test]
        public void Add_ShouldAddTransactionAndIncreaseCount()
        {
            chainblock.Add(transaction);
            Assert.AreEqual(1, chainblock.Count);
            Assert.AreSame(chainblock.GetById(1), transaction);
        }

        [Test]
        public void Contains_ShouldReturnTrueWhenTransactionExists()
        {
            chainblock.Add(transaction);
            Assert.IsTrue(chainblock.Contains(transaction));
        }

        [Test]
        public void Contains_ShouldReturnFalseWhenTransactionDoesNotExists()
        {
            Assert.IsFalse(chainblock.Contains(transaction));
        }

        [Test]
        public void Contains_ShouldReturnTrueWhenIdExists()
        {
            chainblock.Add(transaction);
            Assert.IsTrue(chainblock.Contains(1));
        }

        [Test]
        public void Contains_ShouldReturnFalseWhenIdDoesNotExists()
        {
            Assert.IsFalse(chainblock.Contains(1));
        }

        [Test]
        public void ChangeTransactionStatus_ShouldChangeStatusWithValidArguments()
        {
            chainblock.Add(transaction);
            chainblock.ChangeTransactionStatus(
                1, (TransactionStatus)Enum.Parse(typeof(TransactionStatus), "Aborted"));
            Assert.AreEqual("Aborted", transaction.Status.ToString()); //TODO check if it is OK !!!
        }

        [Test]
        public void ChangeTransactionStatus_ShouldThrowArgumentExceptionWhenStatusIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(
                1, (TransactionStatus)Enum.Parse(typeof(TransactionStatus), "Some Status")));
        }

        [Test]
        public void ChangeTransactionStatus_ShouldThrowArgumentExceptionWhenIIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(
                1, (TransactionStatus)Enum.Parse(typeof(TransactionStatus), "Aborted")));
        }

        [Test]
        public void RemoveTransactionById_ShouldRemoveTransactionWithValidId()
        {
            chainblock.Add(transaction);
            chainblock.RemoveTransactionById(1);
            Assert.AreEqual(0, chainblock.Count);
        }

        [Test]
        public void RemoveTransactionById_ShouldThrowInvalidOperationExceptionIfIdDoesNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(1));
        }

        [Test]
        public void GetById_ShouldReturnCorrectTransactionWithValidId()
        {
            chainblock.Add(transaction);
            var actual = chainblock.GetById(1);

            Assert.AreSame(transaction, actual);
        }

        [Test]
        public void GetById_ShouldTrowInvalidOperationExceptionIfIdDoesNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(1));
        }

        [Test]
        public void GetByTransactionStatus_ShouldReturnTransactionStatusWithValidArgument()
        {
            chainblock.Add(transaction);
            var secondTransaction = new Transaction(2, "Successfull", "Niki", "Pepi", 3000);
            var thirdTransaction = new Transaction(3, "Failed", "Tisho", "Gancho", 1000);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            var actual = chainblock.GetByTransactionStatus(
                (TransactionStatus)Enum.Parse(typeof(TransactionStatus), "Successfull")).ToList();

            Assert.AreSame(secondTransaction, actual[0]);
            Assert.AreSame(transaction, actual[1]);
            Assert.AreEqual(2, actual.Count);
        }

        [Test]
        public void GetByTransactionStatus_ShouldThrowInvalidOperationExceptionIfNoTransactionsFound()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(
                 (TransactionStatus)Enum.Parse(typeof(TransactionStatus), "Failed")));
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ShouldReturnOrderedCorrectListWithValidArgument()
        {
            chainblock.Add(transaction);
            var secondTransaction = new Transaction(2, "Successfull", "Niki", "Pepi", 3000);
            var thirdTransaction = new Transaction(3, "Successfull", "Pesho", "Gancho", 1000);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            var actual = chainblock.GetAllSendersWithTransactionStatus(
                (TransactionStatus)Enum.Parse(typeof(TransactionStatus), "Successfull")).ToList();

            Assert.AreEqual("Niki", actual[0]);
            Assert.AreEqual("Pesho", actual[1]);
            Assert.AreEqual("Pesho", actual[2]);
            Assert.AreEqual(3, actual.Count);
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ShouldThrowInvalidOperationExceptionIfNoSendersFound()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllSendersWithTransactionStatus(
                (TransactionStatus)Enum.Parse(typeof(TransactionStatus), "Failed")));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ShouldReturnOrderedCorrectListWithValidArgument()
        {
            chainblock.Add(transaction);
            var secondTransaction = new Transaction(2, "Successfull", "Niki", "Gosho", 3000);
            var thirdTransaction = new Transaction(3, "Successfull", "Pesho", "Gancho", 1000);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            var actual = chainblock.GetAllReceiversWithTransactionStatus(
                (TransactionStatus)Enum.Parse(typeof(TransactionStatus), "Successfull")).ToList();

            Assert.AreEqual("Gosho", actual[0]);
            Assert.AreEqual("Gosho", actual[1]);
            Assert.AreEqual("Gancho", actual[2]);
            Assert.AreEqual(3, actual.Count);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ShouldThrowInvalidOperationExceptionIfNoSendersFound()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllReceiversWithTransactionStatus(
                (TransactionStatus)Enum.Parse(typeof(TransactionStatus), "Failed")));
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ShouldReturnOrderedListWithTransactions()
        {
            chainblock.Add(transaction);
            var secondTransaction = new Transaction(2, "Successfull", "Niki", "Gosho", 3000);
            var thirdTransaction = new Transaction(3, "Successfull", "Vasko", "Gancho", 1000);
            var fourthTransaction = new Transaction(4, "Successfull", "Toni", "Spas", 2000);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);
            chainblock.Add(fourthTransaction);

            var actual = chainblock.GetAllOrderedByAmountDescendingThenById().ToList();

            Assert.AreEqual(4, actual.Count);
            Assert.AreSame(secondTransaction, actual[0]);
            Assert.AreSame(transaction, actual[1]);
            Assert.AreSame(fourthTransaction, actual[2]);
            Assert.AreSame(thirdTransaction, actual[3]);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldReturnOrderedListOfTransactionsWithValidSender()
        {
            chainblock.Add(transaction);
            var secondTransaction = new Transaction(2, "Successfull", "Niki", "Pepi", 3000);
            var thirdTransaction = new Transaction(3, "Successfull", "Pesho", "Gancho", 1000);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);

            var actual = chainblock.GetBySenderOrderedByAmountDescending("Pesho").ToList();

            Assert.AreEqual(2, actual.Count);
            Assert.AreSame(transaction, actual[0]);
            Assert.AreSame(thirdTransaction, actual[1]);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldThrowInvalidOperationExceptionIfNoTransactions()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock
            .GetBySenderOrderedByAmountDescending("Atanas"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldReturnOrderedListOfTransactionsWithValidReciever()
        {
            chainblock.Add(transaction);
            var secondTransaction = new Transaction(2, "Successfull", "Niki", "Gosho", 3000);
            var thirdTransaction = new Transaction(3, "Successfull", "Pesho", "Gosho", 2000);
            var fourthTransaction = new Transaction(4, "Successfull", "Toni", "Gancho", 2000);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);
            chainblock.Add(fourthTransaction);

            var actual = chainblock.GetByReceiverOrderedByAmountThenById("Gosho").ToList();

            Assert.AreEqual(3, actual.Count);
            Assert.AreSame(secondTransaction, actual[0]);
            Assert.AreSame(transaction, actual[1]);
            Assert.AreSame(thirdTransaction, actual[2]);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldThrowInvalidOperationExceptionIfNoTransactions()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock
            .GetByReceiverOrderedByAmountThenById("Atanas"));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnCorrectTransactionsWithValidArguments()
        {
            var secondTransaction = new Transaction(2, "Successfull", "Niki", "Gosho", 1000);
            var thirdTransaction = new Transaction(3, "Successfull", "Pesho", "Gosho", 1500);
            var fourthTransaction = new Transaction(4, "Successfull", "Toni", "Gancho", 3000);
            chainblock.Add(transaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);
            chainblock.Add(fourthTransaction);

            var actual = chainblock.GetByTransactionStatusAndMaximumAmount(
                (TransactionStatus)Enum.Parse(typeof(TransactionStatus), "Successfull"), 2000).ToList();

            Assert.AreEqual(3, actual.Count);
            Assert.AreSame(transaction, actual[0]);
            Assert.AreSame(thirdTransaction, actual[1]);
            Assert.AreSame(secondTransaction, actual[2]);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsAnEmptyCollectionIfNoTransactionsWithGivenStatusFound()
        {
            chainblock.Add(transaction);
            var actual = chainblock.GetByTransactionStatusAndMaximumAmount(
                (TransactionStatus)Enum.Parse(typeof(TransactionStatus), "Failed"), 1000).ToList();
            Assert.AreEqual(0, actual.Count);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsAnEmptyCollectionIfNoTransactionsWithGivenAmountFound()
        {
            var actual = chainblock.GetByTransactionStatusAndMaximumAmount(
                (TransactionStatus)Enum.Parse(typeof(TransactionStatus), "Successfull"), 1000).ToList();
            Assert.AreEqual(0, actual.Count);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShoudReturnListOfTransactionsWithValidArguments()
        {
            var secondTransaction = new Transaction(2, "Successfull", "Niki", "Gosho", 1000);
            var thirdTransaction = new Transaction(3, "Successfull", "Pesho", "Gosho", 1500);
            var fourthTransaction = new Transaction(4, "Successfull", "Pesho", "Gancho", 3000);
            chainblock.Add(transaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);
            chainblock.Add(fourthTransaction);

            var actual = chainblock.GetBySenderAndMinimumAmountDescending("Pesho", 1000).ToList();

            Assert.AreEqual(3, actual.Count);
            Assert.AreSame(fourthTransaction, actual[0]);
            Assert.AreSame(transaction, actual[1]);
            Assert.AreSame(thirdTransaction, actual[2]);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldThrowInvalidOperationExceptionWithInvalidName()
        {
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => chainblock
            .GetBySenderAndMinimumAmountDescending("Vasko", 2000));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldThrowInvalidOperationExceptionWithNoTransactionsWithGivenAmounts()
        {
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => chainblock
            .GetBySenderAndMinimumAmountDescending("Pesho", 20000));
        }


        //[Test]
        //public void GetByReceiverAndAmountRange_ShouldReturnCorrectOrderedTransactionCollectionValidArgs()
        //{
        //    var secondTransaction = new Transaction(2, "Successfull", "Niki", "Gosho", 1000);
        //    var thirdTransaction = new Transaction(3, "Successfull", "Pesho", "Gosho", 2000);
        //    var fourthTransaction = new Transaction(4, "Successfull", "Pesho", "Gancho", 3000);

        //    chainblock.Add(transaction);
        //    chainblock.Add(secondTransaction);
        //    chainblock.Add(thirdTransaction);
        //    chainblock.Add(fourthTransaction);

        //    var actual = chainblock.GetByReceiverAndAmountRange("Gosho", 1000, 2000).ToList();

        //    Assert.AreEqual(3, actual.Count);
        //    Assert.AreSame(chainblock, actual[0]);
        //    Assert.AreSame(thirdTransaction, actual[1]);
        //    Assert.AreSame(secondTransaction, actual[2]);
        //}

        [Test]
        public void GetByReceiverAndAmountRange_ShouldThrowInvalidOperationExceptionIfInvalidReciever()
        {
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => chainblock
            .GetByReceiverAndAmountRange("Ivan", 0, 2000));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldThrowInvalidOperationExceptionIfNoTransacionsInRange()
        {
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => chainblock
            .GetByReceiverAndAmountRange("Pesho", 0, 100));
        }

        [Test]
        public void GetAllInAmountRange_ShouldReturnCorrectListOfTransactions()
        {
            var secondTransaction = new Transaction(2, "Successfull", "Niki", "Gosho", 1000);
            var thirdTransaction = new Transaction(3, "Successfull", "Pesho", "Gosho", 3000);
            var fourthTransaction = new Transaction(4, "Successfull", "Pesho", "Gancho", 2000);

            chainblock.Add(transaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);
            chainblock.Add(fourthTransaction);

            var actual = chainblock.GetAllInAmountRange(1000, 2000).ToList();

            Assert.AreEqual(3, actual.Count);
            Assert.AreSame(transaction, actual[0]);
            Assert.AreSame(secondTransaction, actual[1]);
            Assert.AreSame(fourthTransaction, actual[2]);
        }

        [Test]
        public void GetAllInAmountRange_SholudReturnAnEmptyListIfNoTransactionsFound()
        {
            var secondTransaction = new Transaction(2, "Successfull", "Niki", "Gosho", 1000);

            chainblock.Add(transaction);
            chainblock.Add(secondTransaction);

            var actual = chainblock.GetAllInAmountRange(1, 100).ToList();

            Assert.AreEqual(0, actual.Count);
        }
    }
}
