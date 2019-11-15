namespace P08.MilitaryElite.Models
{
    public class Repair
    {
        private string name;
        private int hoursWorked;

        public Repair(string name, int hoursWorked)
        {
            this.name = name;
            this.hoursWorked = hoursWorked;
        }

        public override string ToString()
        {
            return $"Part Name: {this.name} Hours Worked: {this.hoursWorked}";
        }
    }
}
