namespace P08.MilitaryElite.Models
{
    using P08.MilitaryElite.Contracts;


    public abstract class Soldier : ISoldier
    {
        private int id;
        private string firstName;
        private string lastName;

        protected Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} ";
        }
    }
}
