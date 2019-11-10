namespace P04.PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;
        public Pizza(string name, Dough dough)
        {
            this.dough = dough;
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;

            set
            {
                if (/*string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)*/ value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }
        public double TotalCalories => this.dough.GetTotalCalories() + this.toppings.Sum(t => t.GetTotalCalories());

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}
