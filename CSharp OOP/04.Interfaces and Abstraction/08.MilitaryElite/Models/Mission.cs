namespace P08.MilitaryElite.Models
{
    using P08.MilitaryElite.Enumerations;

    public class Mission
    {
        private string codeName;

        private States state;

        public Mission(string codeName, States state)
        {
            this.codeName = codeName;
            this.state = state;
        }

        public void CompleteMission()
        {
            this.state = States.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.codeName} State: {this.state.ToString()}";
        }
    }
}
