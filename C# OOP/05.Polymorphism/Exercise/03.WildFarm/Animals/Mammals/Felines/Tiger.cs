namespace P03.WildFarm.Animals.Mammals.Felines
{
    using System;

    public class Tiger : Feline
    {
        private const double weightGrow = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed) :
            base(name, weight, livingRegion, breed)
        {
            this.AllowedFood.Add("Meat");
        }

        protected override double WeightGrow => weightGrow;

        public override void AskForFood()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
