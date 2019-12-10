using System;

namespace P04.PizzaCalories
{
    internal class PizzaFactory
    {
        private DoughFactory doughFactory = new DoughFactory();

        internal Pizza Create()
        {
            var pizzaName = Console.ReadLine().Split(' ')[1];
            var doughArgs = Console.ReadLine().Split(' ');

            var dough = doughFactory.Create(doughArgs);

            return new Pizza(pizzaName, dough);
        }
    }
}