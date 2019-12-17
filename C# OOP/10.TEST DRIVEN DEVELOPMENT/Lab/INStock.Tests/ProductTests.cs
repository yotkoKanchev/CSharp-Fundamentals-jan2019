namespace INStock.Tests
{
    using NUnit.Framework;
    using Contracts;
    using Data;

    public class ProductTests
    {
        private IProduct product;

        [SetUp]
        public void Setup()
        {
            this.product = new Product("Bread", 1.5m, 10);
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            Assert.AreEqual("Bread", product.Label);
            Assert.AreEqual(1.5, product.Price);
            Assert.AreEqual(10, product.Quantity);
        }

        [Test]
        public void CompareTo_ShouldReturnZeroWhenProductsHasEqualPrices()
        {
            var secondProduct = new Product("Wine", 1.5m, 10);
            var actual = product.CompareTo(secondProduct);

            Assert.AreEqual(0, actual);
        }

        [Test]
        public void CompareTo_ShouldReturnOneWhenFirstProductIsMoreExpensive()
        {
            var secondProduct = new Product("Wine", 1.1m, 10);
            var actual = product.CompareTo(secondProduct);

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void CompareTo_ShouldReturnMinusOneWhenSecondProductIsMoreExpensive()
        {
            var secondProduct = new Product("Wine", 2.5m, 10);
            var actual = product.CompareTo(secondProduct);

            Assert.AreEqual(-1, actual);
        }
    }
}