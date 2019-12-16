using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    public Hero.Hero hero;

    [SetUp]
    public void Setup()
    {
        this.hero = new Hero.Hero("Geroy");
    }

    [Test]
    public void ConstructorCreateInstance()
    {
        var actualExperience = hero.Experience;
        var actualName = hero.Name;
        var expectedExperiance = 0;
        var expectedName = "Geroy";
        Assert.AreEqual(expectedExperiance, actualExperience);
        Assert.AreEqual(expectedName, actualName);
    }

    [Test]
    public void ConstructorSetAxeWeapon()
    {
        var actual = hero.Weapon.AttackPoints;
        var expected = 10;
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void AttackIncreaseExperiance()
    {
        var dummy = new Dummy(5, 5);
        hero.Attack(dummy);
        var actual = hero.Experience;
        var expected = 5;
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void AttackDoNotIncreaseExperianceWhenTragetIsStillAlive()
    {
        var dummy = new Dummy(15, 15);
        hero.Attack(dummy);
        var actual = hero.Experience;
        var expected = 0;
        Assert.AreEqual(expected, actual);
    }
}
