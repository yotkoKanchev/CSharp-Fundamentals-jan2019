namespace Tests
{
    using NUnit.Framework;
    using System;
    using ExtendedDatabase;

    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase extendedDatabase;

        [SetUp]
        public void Setup()
        {
            var persons = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                persons[i] = new Person(i, $"Gosho{i + 1}");
            }

            this.extendedDatabase = new ExtendedDatabase(persons);
        }

        [Test]
        public void Constructor_ShouldInitializeDatabaseWithValidArguments()
        {
            var actual = extendedDatabase.Count;
            var expected = 16;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConstructorAddRange_ShouldThrowArgumentExceptionIfArrayHasMoreElements()
        {
            var persons = new Person[17];

            for (int i = 0; i < 17; i++)
            {
                persons[i] = new Person(i, $"Gosho{i + 1}");
            }

            Assert.Throws<ArgumentException>(() => this.extendedDatabase = new ExtendedDatabase(persons));
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationExceptionWhenArrayIsFull()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(new Person(17, "Todor")));
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationExceptionWhenPersonExistsValidNonExistingId()
        {
            var persons = new Person[15];

            for (int i = 0; i < 15; i++)
            {
                persons[i] = new Person(i, $"Gosho{i + 1}");
            }

            this.extendedDatabase = new ExtendedDatabase(persons);
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(new Person(16, "Gosho1")));
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationExceptionWhenIdExistsWithValidNonexistingName()
        {
            var persons = new Person[15];

            for (int i = 0; i < 15; i++)
            {
                persons[i] = new Person(i, $"Gosho{i + 1}");
            }

            this.extendedDatabase = new ExtendedDatabase(persons);
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(new Person(1, "Gosho")));
        }


        [Test]
        public void Add_ShouldAddPersonWithValidArguments()
        {
            var persons = new Person[15];

            for (int i = 0; i < 15; i++)
            {
                persons[i] = new Person(i, $"Gosho{i + 1}");
            }

            this.extendedDatabase = new ExtendedDatabase(persons);
            extendedDatabase.Add(new Person(16, "Todor"));

            var actual = extendedDatabase.Count;
            var expected = 16;

            var person = extendedDatabase.FindById(16);
            var personName = person.UserName;
            var expectedName = "Todor";
            var personId = person.Id;
            var expectedId = 16;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedName, personName);
            Assert.AreEqual(expectedId, personId);
        }

        [Test]
        public void Remove_ShouldThrowInvalidOperationExceptionWhenArayIsEmpty()
        {
            var database = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_ShouldRemoveLastPersonAndDecreaseCount()
        {
            this.extendedDatabase.Remove();
            var actual = this.extendedDatabase.Count;
            var expected = 15;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindByUsername_ShouldThrowArgumentNullExceptionWhenArgumentIsAnEmptyString()
        {
            Assert.Throws<ArgumentNullException>(() => this.extendedDatabase.FindByUsername(""));
        }

        [Test]
        public void FindByUsername_ShouldThrowArgumentNullExceptionWhenArgumentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.extendedDatabase.FindByUsername(null));
        }

        [Test]
        public void FindByUsername_ShouldThrowInvalidOperationExceptionWhenUsernameIsNotValid()
        {
            var database = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("XXX"));
        }

        [Test]
        public void FindByUsername_ShouldReturnCorrectPersonWithValidArgument()
        {
            var actual = this.extendedDatabase.FindByUsername("Gosho1");
            var expected = this.extendedDatabase.FindById(0);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindById_ShouldThrowArgumentOutOfRangeExceptionWithNegativeIdArgument()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.extendedDatabase.FindById(-1));
        }

        [Test]
        public void FindById_ShouldThrowInvalidOperationExceptionWithUnexistingId()
        {
            var person = new Person(0, "Vasko");
            var database = new ExtendedDatabase(person);

            Assert.Throws<InvalidOperationException>(() => database.FindById(1));
        }

        [Test]
        public void FindById_ShouldReturnTheCorrectPersonWithValidId()
        {
            var actual = this.extendedDatabase.FindById(0);
            var expected = this.extendedDatabase.FindByUsername("Gosho1");
            Assert.AreEqual(expected, actual);
        }
    }
}