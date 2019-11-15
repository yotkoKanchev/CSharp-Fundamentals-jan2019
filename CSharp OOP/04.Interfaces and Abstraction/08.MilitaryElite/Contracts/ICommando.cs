namespace P08.MilitaryElite.Contracts
{
    using Models;
    using System.Collections.Generic;
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyList<Mission> Missions { get; }
    }
}
