namespace P08.MilitaryElite.Models
{
    using Contracts;
    using Enumerations;
    using System.Text;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {

        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corp) 
            : base(id, firstName, lastName, salary)
        {
            this.Corp = corp;
        }

        public Corps Corp { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corp.ToString()}");

            return sb.ToString().TrimEnd();
        }
    }
}
