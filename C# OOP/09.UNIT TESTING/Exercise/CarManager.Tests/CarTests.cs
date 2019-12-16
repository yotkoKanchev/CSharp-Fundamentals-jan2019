using NUnit.Framework;

namespace Tests
{
    //using CarManager;
    using System;

    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            this.car = new Car("VW", "Golf", 2, 20);
        }

        [Test]
        public void Constructor_ShouldInitializeCar()
        {
            Assert.AreEqual("VW", car.Make);
            Assert.AreEqual("Golf", car.Model);
            Assert.AreEqual(2, car.FuelConsumption);
            Assert.AreEqual(20, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void MakeSetter_ShouldThrowArgumentExceptionWithEmptyArgument()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("", "Golf", 2, 20));
        }

        [Test]
        public void MakeSetter_ShouldThrowArgumentExceptionWithNullArgument()
        {
            Assert.Throws<ArgumentException>(() => car = new Car(null, "Golf", 2, 20));
        }

        [Test]
        public void ModelSetter_ShouldThrowArgumentExceptionWithEmptyArgument()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("VW", "", 2, 20));
        }

        [Test]
        public void ModelSetter_ShouldThrowArgumentExceptionWithNullArgument()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("VW", null, 2, 20));
        }

        [Test]
        public void FuelConsumptionSetter_ShouldThrowArgumentExceptionWhenArgumentIsZero()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("VW", "Golf", 0, 20));
        }

        [Test]
        public void FuelConsumptionSetter_ShouldThrowArgumentExceptionWhenArgumentIsNegative()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("VW", "Golf", -1, 20));
        }

        [Test]
        public void FuelAmountSetter_ShouldThrowArgumentExceptionWhenArgumentIsZero()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("VW", "Golf", 2, 0));
        }

        [Test]
        public void FuelAmountSetter_ShouldThrowArgumentExceptionWhenArgumentIsNegative()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("VW", "Golf", 2, -20));
        }

        [Test]
        public void FuelCapacitySetter_ShouldThrowArgumentExceptionWhenArgumentIsZero()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("VW", "Golf", 2, 0));
        }

        [Test]
        public void FuelCapacitySetter_ShouldThrowArgumentExceptionWhenArgumentIsNegative()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("VW", "Golf", 2, -20));
        }

        [Test]
        public void RefuelSetter_ShouldThrowArgumentExceptionWhenArgumentIsZero()
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(0));
        }

        [Test]
        public void Refuel_ShouldThrowArgumentExceptionWhenArgumentIsNegative()
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(-1));
        }

        [Test]
        public void Refuel_IncreaseFuelAmountWithArgumentLessThanRemainingAmountOfFuel()
        {
            this.car.Refuel(5);
            var actual = this.car.FuelAmount;
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Refuel_IncreaseFuelAmountWithArgumentMoreThanRemainingAmountOfFuel()
        {
            this.car.Refuel(25);
            var actual = this.car.FuelAmount;
            var expected = 20;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Drive_ShouldThrowInvalidOperationExceptionWhenArgumentIsNegative()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(1000));
        }

        [Test]
        public void Drive_ShouldDecreaseFuelAmountWithValidArgument()
        {
            this.car.Refuel(10);
            this.car.Drive(100);
            var actual = car.FuelAmount;
            var expected = 8;
            Assert.AreEqual(expected, actual);
        }
    }
}