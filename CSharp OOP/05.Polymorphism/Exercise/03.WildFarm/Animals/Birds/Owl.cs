namespace P03.WildFarm.Animals.Birds
{
    using System;

    public class Owl : Bird
    {
        private const double weightGrow = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.AllowedFood.Add("Meat");
        }

        protected override double WeightGrow => weightGrow;

        public override void AskForFood()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
