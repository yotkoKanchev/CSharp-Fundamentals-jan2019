namespace P08.MilitaryElite.Contracts
{
    using P08.MilitaryElite.Enumerations;

    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corp { get; }
    }
}
