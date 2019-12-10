namespace P03.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var people = new List<Person>();
            var products = new List<Product>();

            var peopleArgs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            var productsArgs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                foreach (var args in peopleArgs)
                {
                    var personArgs = args.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    var name = personArgs[0];
                    var money = decimal.Parse(personArgs[1]);
                    people.Add(new Person(name, money));
                }

                foreach (var args in productsArgs)
                {
                    var currentArgs = args.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    var name = currentArgs[0];
                    var cost = decimal.Parse(currentArgs[1]);
                    products.Add(new Product(name, cost));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input?.ToLower() == "end")
                {
                    break;
                }

                var args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var personName = args[0];
                var productName = args[1];

                var person = people.FirstOrDefault(p => p.Name == personName);
                var product = products.FirstOrDefault(p => p.Name == productName);

                if (person != null && product != null)
                {
                    Console.WriteLine(person.BuyProduct(product));
                }
            }

            people.ForEach(p => Console.WriteLine(p));
        }
    }
}
