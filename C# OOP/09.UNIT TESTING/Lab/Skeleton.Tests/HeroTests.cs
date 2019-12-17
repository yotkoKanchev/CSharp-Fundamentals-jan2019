using NUnit.Framework;
using Moq;
using Skeleton;

public class HeroTests
{
    public void Hero_GainsExperienceAfterAttackIfTargetDies()
    {
        var mockTarget = new Mock<ITarget>();
        mockTarget.Setup(p => p.Health).Returns(0);
        mockTarget.Setup(p => p.IsDead()).Returns(true);
        mockTarget.Setup(p => p.GiveExperience()).Returns(20);

        var mockWeapon = new Mock<IWeapon>();

        var hero = new Hero("Pesho", mockWeapon.Object);

        hero.Attack(mockTarget.Object);
        Assert.AreEqual(20, hero.Experience);
    }
}
