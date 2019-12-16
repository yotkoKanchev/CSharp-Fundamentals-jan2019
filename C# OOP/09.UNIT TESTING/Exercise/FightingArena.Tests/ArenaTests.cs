namespace Tests
{
    using NUnit.Framework;
    using System;
    using FightingArena;

    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void Constructor_InitializeCorrectlyWithEmptyWorriorsCollection()
        {
            var actual = arena.Count;
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Enroll_ShouldAddWarriorToTheCollectionAndIncreaseCount()
        {
            arena.Enroll(new Warrior("Shrek", 40, 40));
            var actual = arena.Count;
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Enroll_ShouldThrowInvalidOperationExceptionWhenWarriorExists()
        {
            arena.Enroll(new Warrior("Shrek", 40, 40));
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("Shrek", 100, 100)));
        }

        [Test]
        public void Fight_ShouldThrowInvalidOperationExceptionWhenAttackerNameDidNotExist()
        {
            arena.Enroll(new Warrior("Shrek", 40, 40));
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Shrek", "Fiona"));
        }

        [Test]
        public void Fight_ShouldThrowInvalidOperationExceptionWhenDeffenderNameDidNotExist()
        {
            arena.Enroll(new Warrior("Fiona", 50, 50));
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Shrek", "Fiona"));
        }

        [Test]
        public void Fight_ShouldDecreaseHPOfBothWarriors()
        {
            var attacker = new Warrior("Shrek", 50, 100);
            var deffender = new Warrior("Fiona", 40, 100);

            arena.Enroll(attacker);
            arena.Enroll(deffender);

            arena.Fight("Shrek", "Fiona");

            var actualAttackerHp = attacker.HP;
            var expectedAttackerHp = 60;
            var actualDeffenderHp = deffender.HP;
            var expectedDeffenderHp = 50;

            Assert.AreEqual(expectedAttackerHp, actualAttackerHp);
            Assert.AreEqual(expectedDeffenderHp, actualDeffenderHp);
        }
    }
}
