namespace P03.WildFarm.Animals.Mammals
{
    using System;

    public class Dog : Mammal
    {
        private const double weightGrow = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            this.AllowedFood.Add("Meat");
        }

        protected override double WeightGrow => weightGrow;

        public override void AskForFood()
        {
            Console.WriteLine("Woof!");
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
