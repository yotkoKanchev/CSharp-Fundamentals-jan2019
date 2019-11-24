namespace P03.WildFarm.Animals
{
    using P03.WildFarm.Foods;
    using System;
    using System.Collections.Generic;

    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
            this.AskForFood();
            this.AllowedFood = new List<string>();
        }

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        protected abstract double WeightGrow { get; }

        protected List<string> AllowedFood { get; set; }

        public abstract void AskForFood();

        public void Eat(Food food)
        {
            var foodType = food.GetType().Name;

            if (!this.AllowedFood.Contains(foodType))
            {
                throw new ArgumentException($"{ this.GetType().Name } does not eat { foodType}!");
            }

            this.Weight += food.Quantity * this.WeightGrow;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
