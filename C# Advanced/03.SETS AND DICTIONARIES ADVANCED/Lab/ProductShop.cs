namespace _03._Product_Shop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ProductShop
    {
        static void Main(string[] args)
        {
            var stores = new Dictionary<string, Dictionary<string, double>>();

            string inputLine = Console.ReadLine();

            while (inputLine?.ToLower() != "revision")
            {
                string[] tokens = inputLine.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string storeName = tokens[0];
                string product = tokens[1];
                double productPrice = double.Parse(tokens[2]);

                if (!stores.ContainsKey(storeName))
                {
                    stores[storeName] = new Dictionary<string, double>();
                }

                if (!stores[storeName].ContainsKey(product))
                {
                    stores[storeName][product] = 0;
                }

                stores[storeName][product] = productPrice;

                inputLine = Console.ReadLine();
            }

            foreach (var kvp in stores.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{kvp.Key}->");
                foreach (var productKvp in kvp.Value)
                {
                    Console.WriteLine($"Product: {productKvp.Key}, Price: {productKvp.Value}");
                }
            }
        }
    }
}
