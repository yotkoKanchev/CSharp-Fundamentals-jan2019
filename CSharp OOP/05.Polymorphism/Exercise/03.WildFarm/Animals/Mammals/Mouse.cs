namespace P03.WildFarm.Animals.Mammals
{
    using System;

    public class Mouse : Mammal
    {
        private const double weightGrow = 0.10;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            this.AllowedFood.AddRange(new string[] { "Vegetable", "Fruit", });
        }

        protected override double WeightGrow => weightGrow;

        public override void AskForFood()
        {
            Console.WriteLine("Squeak");
        }
        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
