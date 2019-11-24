namespace P03.WildFarm.Animals.Birds
{
    using System;

    public class Hen : Bird
    {
        private const double weightGrow = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.AllowedFood.AddRange(new string[] { "Vegetable", "Fruit", "Meat", "Seeds" });
        }

        protected override double WeightGrow => weightGrow;

        public override void AskForFood()
        {
            Console.WriteLine("Cluck");
        }
    }
}
