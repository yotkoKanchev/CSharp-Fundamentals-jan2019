namespace Chainblock.Tests
{
    using NUnit.Framework;
    using Data;

    public class TransactionTests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            var transaction = new Transaction(1, "Successfull", "Gosho", "Gosho", 2000.50);

            Assert.AreEqual(1, transaction.Id);
            Assert.AreEqual("Successfull", transaction.Status.ToString());
            Assert.AreEqual("Gosho", transaction.From);
            Assert.AreEqual("Gosho", transaction.To);
            Assert.AreEqual(2000.50, transaction.Amount);
        }
    }
}
