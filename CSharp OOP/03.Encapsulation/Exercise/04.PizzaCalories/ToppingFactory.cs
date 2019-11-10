namespace P04.PizzaCalories
{
    using System;

    internal class ToppingFactory
    {
        internal Topping Create(string input)
        {
            var toppingArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var toppingType = toppingArgs[1];
            var toppingWeight = int.Parse(toppingArgs[2]);

            return new Topping(toppingWeight, toppingType);
        }
    }
}
