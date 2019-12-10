using System;
using System.Collections.Generic;
using System.Text;

namespace P04.PizzaCalories
{
    internal class DoughFactory
    {
        internal Dough Create(string[] doughArgs)
        {
            var flourType = doughArgs[1];
            var bakingType = doughArgs[2];
            var weight = int.Parse(doughArgs[3]);

            return new Dough(weight, flourType, bakingType);
        }
    }
}
