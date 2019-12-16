namespace Tests
{
    using NUnit.Framework;
    using System;
    using FightingArena;

    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Shrek", 50, 50);
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            Assert.AreEqual("Shrek", warrior.Name);
            Assert.AreEqual(50, warrior.Damage);
            Assert.AreEqual(50, warrior.HP);
        }

        [Test]
        public void NameSetter_ShouldThrowArgumentExceptionWithNullgArgument()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(null, 50, 50));
        }

        [Test]
        public void NameSetter_ShouldThrowArgumentExceptionWithWhiteSpaceArgument()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(" ", 50, 50));
        }

        [Test]
        public void NameSetter_ShouldThrowArgumentExceptionWithEmptyStringgArgument()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("", 50, 50));
        }
       

        [Test]
        public void DamageSetter_ShouldThrowArgumentExceptionWithZeroArgument()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("Shrek", 0, 50));
        }

        [Test]
        public void DamageSetter_ShouldThrowArgumentExceptionWithNEgativeArgument()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("Shrek", -1, 50));
        }

        [Test]
        public void HPSetter_ShouldThrowArgumentExceptionWithNEgativeArgument()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("Shrek", 50, -1));
        }

        [Test]
        public void Attack_ShouldThrowInvalidOperationExceptionWithLessHpThanMinimumAttackHp()
        {
            var attacker = new Warrior("Shrek", 10, 10);
            var deffender = new Warrior("Fiona", 5, 40);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(deffender));
        }

        [Test]
        public void Attack_ShouldThrowInvalidOperationExceptionWithEqualHpThanMinimumAttackHp()
        {
            var attacker = new Warrior("Shrek", 50, 30);
            var deffender = new Warrior("Fiona", 50, 50);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(deffender));
        }

        [Test]
        public void Attack_ShouldThrowInvalidOperationExceptionWhenEnemyHpIsLessHpThanMinimumAttackHp()
        {
            var attacker = new Warrior("Shrek", 30, 40);
            var secondWarrior = new Warrior("Fiona", 10, 10);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(secondWarrior));
        }

        [Test]
        public void Attack_ShouldThrowInvalidOperationExceptionWhenEnemyHpIsEqualHpThanMinimumAttackHp()
        {
            var attacker = new Warrior("Shrek", 50, 50);
            var secondWarrior = new Warrior("Fiona", 50, 30);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(secondWarrior));
        }

        [Test]
        public void Attack_ShouldThrowInvalidOperationExceptionWhenEnemyDemageIsGreaterThanWarrierHp()
        {
            var attacker = new Warrior("Shrek", 10, 40);
            var secondWarrior = new Warrior("Fiona", 50, 50);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(secondWarrior));
        }

        [Test]
        public void Attack_ShouldDecreaseHp()
        {
            var secondWarrior = new Warrior("Fiona", 40, 40);
            warrior.Attack(secondWarrior);
            var actual = warrior.HP;
            var expected = 10;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Attack_ShouldSetEnemyHpToZeroWhenDamageIsGreaterThenEnemyHp()
        {
            var secondWarrior = new Warrior("Fiona", 40, 40);
            warrior.Attack(secondWarrior);
            var actual = secondWarrior.HP;
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Attack_ShouldDecreaseEnemyHp()
        {
            var secondWarrior = new Warrior("Fiona", 40, 100);
            warrior.Attack(secondWarrior);
            var actual = secondWarrior.HP;
            var expected = 50;
            Assert.AreEqual(expected, actual);
        }
    }
}