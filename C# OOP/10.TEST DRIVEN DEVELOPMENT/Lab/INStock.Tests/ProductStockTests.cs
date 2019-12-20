namespace INStock.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using Contracts;
    using Data;

    public class ProductStockTests
    {
        private IProductStock productStock;
        private IProduct product;
        private IProduct secondProduct;
        private IProduct thirdProduct;

        [SetUp]
        public void Setup()
        {
            this.productStock = new ProductStock();
            this.product = new Product("Wine", 10.2m, 10);
            this.secondProduct = new Product("Beer", 15, 5);
            this.thirdProduct = new Product("Gold", 200, 1);
        }

        [Test]
        public void Constructor_ShouldInitializeWithEmptyCollection()
        {
            Assert.AreEqual(0, productStock.Count);
        }

        [Test]
        public void Add_ShouldAddProductAndIncreaseCount()
        {
            productStock.Add(product);
            Assert.AreEqual(1, productStock.Count);
        }

        [Test]
        public void Contains_ShouldReturnTrueWhenProductExists()
        {
            productStock.Add(product);
            Assert.IsTrue(productStock.Contains(product));
        }

        [Test]
        public void Contains_ShouldReturnFalseWhenProductDoesNotExists()
        {
            Assert.IsFalse(productStock.Contains(product));
        }

        [Test]
        public void Find_ShouldReturnTheCorrectProductOnGiventIndex()
        {
            productStock.Add(product);
            Assert.AreSame(product, productStock.Find(0));
        }

        [Test]
        public void Find_ShouldThrowIndexOutOfRangeExceptionIfGivenIndexIsNotValid()
        {
            productStock.Add(product);
            Assert.Throws<IndexOutOfRangeException>(() => productStock.Find(1));
        }

        [Test]
        public void FindByLabel_ShouldReturnCorrectProductByGivenLabel()
        {
            productStock.Add(product);
            Assert.AreSame(product, productStock.FindByLabel("Wine"));
        }

        [Test]
        public void FindByLabel_ShouldThrowArgumentExceptionIfLabelDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => productStock.FindByLabel("Beer"));
        }

        [Test]
        public void FindAllInPriceRange_ShouldReturnCorectCollectionWithValidArguments()
        {
            productStock.Add(product);
            productStock.Add(secondProduct);
            productStock.Add(thirdProduct);

            var actual = productStock.FindAllInRange(0, 20).ToList();

            Assert.AreEqual(2, actual.Count);
        }

        [Test]
        public void FindAllInPriceRange_ShouldReturnEmptyCollectionWhenProductDoesNotExistInGivenPriceRange()
        {
            var actual = productStock.FindAllInRange(0, 20).ToList();

            Assert.AreEqual(0, actual.Count);
        }

        [Test]
        public void FindAllInPriceRange_ShouldReturnOrderedCollectionWhitValidAdguments()
        {
            productStock.Add(product);
            productStock.Add(secondProduct);

            var actual = productStock.FindAllInRange(0, 20).ToList();

            Assert.AreSame(product, actual[1]);
            Assert.AreSame(secondProduct, actual[0]);
        }

        [Test]
        public void FindAllByPrice_ShouldReturnCorrectCollectionWithValidArguments()
        {
            productStock.Add(product);
            productStock.Add(secondProduct);
            productStock.Add(thirdProduct);

            var actual = productStock.FindAllByPrice(15).ToList();

            Assert.AreEqual(1, actual.Count);
        }

        [Test]
        public void FindAllByPrice_ShouldReturnAnEmptuCollectionIfNotProductsWithGivenPriceFound()
        {
            var actual = productStock.FindAllByPrice(15).ToList();

            Assert.AreEqual(0, actual.Count);
        }

        [Test]
        public void FindMostExpensiveProducts_ShouldReturnTheMostExpensiceProduct()
        {
            
            productStock.Add(product);
            productStock.Add(secondProduct);
            productStock.Add(thirdProduct);

            var actual = productStock.FindMostExpensiveProduct();

            Assert.AreSame(thirdProduct, actual);
        }

        [Test]
        public void FindAllByQuantity_ShouldReturnCorrectCollectionWithValidArgument()
        {
            productStock.Add(product);
            productStock.Add(secondProduct);
            productStock.Add(thirdProduct);

            var actual = productStock.FindAllByQuantity(5).ToList();

            Assert.AreEqual(2, actual.Count);
        }

        [Test]
        public void FindAllByQuantity_ShouldReturnEmptyCollectionIfNoProductsAreFoundByGivenQuantity()
        {
            var actual = productStock.FindAllByQuantity(100).ToList();

            Assert.AreEqual(0, actual.Count);
        }

        [Test]
        public void Indexer_ReturnsCorrectProduct()
        {
            productStock.Add(product);
            Assert.AreSame(product, productStock.Find(0));
        }
    }
}
