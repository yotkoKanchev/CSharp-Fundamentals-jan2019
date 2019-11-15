using System.Collections.Generic;
using System.Text;
using P08.MilitaryElite.Contracts;
using P08.MilitaryElite.Enumerations;

namespace P08.MilitaryElite.Models
{
    class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<Repair> repairs;
        public Engineer(int id, string firstName, string lastName, decimal Salary, Corps corp)
            : base(id, firstName, lastName, Salary, corp)
        {
            this.repairs = new List<Repair>();
        }

        public IReadOnlyList<Repair> Repairs => this.repairs.AsReadOnly();

        public void AddRepair( Repair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs: ");
            foreach (var repair in this.Repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
