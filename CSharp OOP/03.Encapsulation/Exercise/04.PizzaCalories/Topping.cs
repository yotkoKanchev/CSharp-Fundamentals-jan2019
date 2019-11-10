namespace P04.PizzaCalories
{
    using System;
    using System.Linq;
    using static Modifier.Toping;
    public class Topping : Ingredient
    {
        private string name;
        private int weight;
        private string[] validTypes = new string[] { "meat", "veggies", "cheese", "sauce" };

        public Topping(int weight, string name)
        {
            this.Name = name;
            this.Weight = weight;
        }

        internal string Name
        {
            get => this.name;

            set
            {
                if (!validTypes.Contains(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.name = value;
            }
        }

        internal override int Weight
        {
            get => this.weight;
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Name} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        internal override double CaloriesModifier()
        {
            double caloriesModifier = 0;
            var name = this.Name.ToLower();

            if (name == "meat")
            {
                caloriesModifier = Meat;
            }
            else if (name == "veggies")
            {
                caloriesModifier = Veggies;
            }
            else if (name == "cheese")
            {
                caloriesModifier = Cheese;
            }
            else if (name == "sauce")
            {
                caloriesModifier = Sauce;
            }

            return caloriesModifier;
        }
    }
}
