namespace P08.MilitaryElite.Contracts
{
    using P08.MilitaryElite.Models;
    using System.Collections.Generic;

    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyList<Private> Privates { get; }
    }
}
