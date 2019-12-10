namespace P08.MilitaryElite.Models
{
    using Contracts;
    using Enumerations;
    using System.Collections.Generic;
    using System.Text;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<Mission> missions;
        public Commando(int id, string firstName, string lastName, decimal Salary, Corps corp) 
            : base(id, firstName, lastName, Salary, corp)
        {
            this.missions = new List<Mission>();
        }

        public IReadOnlyList<Mission> Missions => this.missions.AsReadOnly();

        public void AddMission (Mission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            foreach (var mission in this.Missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
