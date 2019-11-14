namespace P07.FoodShortage
{
    public class Citizen : Person
    {
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
            : base(name, age)
        {
            this.id = id;
            this.birthdate = birthdate;
        }

        public override void BuyFood()
        {
            this.Food += 10;
        }
    }
}
