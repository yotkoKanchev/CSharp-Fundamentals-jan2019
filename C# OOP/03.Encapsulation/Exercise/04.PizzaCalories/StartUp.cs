namespace P04.PizzaCalories
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var toppingFactory = new ToppingFactory();
            var pizzaFactory = new PizzaFactory();
            try
            {
                var pizza = pizzaFactory.Create();

                while (true)
                {
                    var input = Console.ReadLine();

                    if (input?.ToLower() == "end")
                    {
                        break;
                    }

                    var topping = toppingFactory.Create(input);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
