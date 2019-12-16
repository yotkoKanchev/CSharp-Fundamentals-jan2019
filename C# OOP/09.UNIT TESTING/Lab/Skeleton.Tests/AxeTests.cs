using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    public void Attack_ShouldDropDurabilityPointsAfterAttack()
    {
        var axe = new Axe(1, 10);
        var dummy = new Dummy(10, 10);

        axe.Attack(dummy);

        var actual = axe.DurabilityPoints;
        var expected = 9;

        Assert.AreEqual(expected, actual, "Attack did not decrease durabilty points !");
    }

    [Test]
    public void Attack_ShouldThrowsInvalidOperationExceptionWhenNoDurabilyPoints()
    {
        var axe = new Axe(10, 0);
        var dummy = new Dummy(10, 10);

        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Attack does not throw exeption when not durabilty points.");
    }
}
