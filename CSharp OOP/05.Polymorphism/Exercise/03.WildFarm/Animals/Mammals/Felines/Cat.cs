namespace P03.WildFarm.Animals.Mammals.Felines
{
    using System;

    public class Cat : Feline
    {
        private const double weightGrow = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            this.AllowedFood.AddRange(new string[] { "Vegetable", "Meat", });
        }

        protected override double WeightGrow => weightGrow;

        public override void AskForFood()
        {
            Console.WriteLine("Meow");
        }
    }
}
