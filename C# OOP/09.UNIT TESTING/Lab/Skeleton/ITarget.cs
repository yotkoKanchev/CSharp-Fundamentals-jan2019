namespace Skeleton
{
    public interface ITarget
    {
        int Health { get; }

        void TakeAttack(int points);

        int GiveExperience();

        bool IsDead();
    }
}
