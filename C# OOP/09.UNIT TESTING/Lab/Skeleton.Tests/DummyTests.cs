using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyConstructorCreateInstance()
    {
        var dummy = new Dummy(10, 10);
        var actual = dummy.Health;
        var expected = 10;
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void DummyTakeAttackDropsHealthPoints()
    {
        var dummy = new Dummy(10, 10);
        dummy.TakeAttack(5);
        var actual = dummy.Health;
        var expected = 5;
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Dummy_IsDeadReturnTrueWhenIsDead()
    {
        var dummy = new Dummy(0, 10);
        var actual = dummy.IsDead();
        Assert.IsTrue(actual);
    }

    [Test]
    public void Dummy_IsDeadReturnFalseWhenIsAlive()
    {
        var dummy = new Dummy(10, 10);
        var actual = dummy.IsDead();
        Assert.IsFalse(actual);
    }

    [Test]
    public void DummyLoseHealth_WhenAttacked()
    {
        var dummy = new Dummy(10, 10);
        var axe = new Axe(1, 10);

        axe.Attack(dummy);

        var actual = dummy.Health;
        var expected = 9;

        Assert.AreEqual(expected, actual, "Dummy Health does not decrease when attacked");
    }

    [Test]
    public void DummyThrowsInvalidOperationException_WhenIsDead()
    {
        var dummy = new Dummy(0, 10);
        var axe = new Axe(1, 10);

        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Dummy doesn't throw EX when isDead and Attacked");
    }

    [Test]
    public void DeadDummyGivesXPPointsWhenDies()
    {
        var dummy = new Dummy(10, 10);
        var hero = new Hero.Hero("Vasko");

        hero.Attack(dummy);

        var actual = hero.Experience;
        var expected = 10;

        Assert.AreEqual(expected, actual, "Dummy does not gives XP points when is dead");
    }

    [Test]
    public void DeadDummyDoNotGivesXPPointsWhenIsAlive()
    {
        var dummy = new Dummy(100, 100);
        var hero = new Hero.Hero("Vasko");

        hero.Attack(dummy);

        var actual = hero.Experience;
        var expected = 0;

        Assert.AreEqual(expected, actual, "Dummy gives XP points when is alive");
    }
}
