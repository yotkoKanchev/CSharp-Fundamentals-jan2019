namespace Tests
{
    using NUnit.Framework;
    using System;
    using Database;

    [TestFixture]
    public class DatabaseTests
    {
        private int[] validArray;
        private int[] lessArray;
        private Database database;

        [SetUp]
        public void Setup()
        {
            this.validArray = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            this.lessArray = new int[15] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, };
            this.database = new Database(validArray);
        }

        [Test]
        public void Constructor_ShouldInitaializeWithValidArrayOf16Ints()
        {
            var actual = database.Count;
            var expected = 16;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_ShouldTrowInvalidOperationExceptionWhenAddMoreThan16ElementsInArray()
        {
            Assert.Throws<InvalidOperationException>(() => database.Add(17),
                "Add did not throw EX when more than capacity elements added !");
        }

        [Test]
        public void Add_ShouldAddNewElementAndiIncreaseCount()
        {
            this.database = new Database(lessArray);

            database.Add(16);

            var actual = database.Count;
            var expected = 16;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Remove_ShouldRemoveAnElement()
        {
            database.Remove();
            var actual = database.Count;
            var expected = 15;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Remove_ShouldTrowInvalidOperationWhenCollectionIsEmpty()
        {
            this.database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove(),
                "Remove did not throw EX when collection is empty!");
        }

        [Test]
        public void Fetch_ShouldCopyArrayCorrectly()
        {
            this.database = new Database(new int[] { 1 });
            var resultArray = database.Fetch();
            var actual = resultArray.Length;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Fetch_ShouldReturnIntArrayType()
        {
            this.database = new Database(new int[] { 1 });
            var resultArray = database.Fetch();
            var actual = resultArray.GetType().Name;
            var expected = "Int32[]";
            Assert.AreEqual(expected, actual);
        }
    }
}