namespace P08.MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<Private> privates;
        public LieutenantGeneral(int id, string firstName, string lastName, decimal Salary)
            : base(id, firstName, lastName, Salary)
        {
            this.privates = new List<Private>();
        }

        public IReadOnlyList<Private> Privates => this.privates.AsReadOnly();

        public void AddPrivate(Private @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine("Privates:");

            foreach (var @private in this.Privates)
            {
                sb.AppendLine($"  {@private.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
