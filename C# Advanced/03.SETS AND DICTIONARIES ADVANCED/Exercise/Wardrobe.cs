namespace _06._Wardrobe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Wardrobe
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string,int>> wardrobe = new Dictionary<string, Dictionary<string,int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = tokens[0];
                List<string> items = tokens[1].Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                foreach (var item in items)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color][item] = 0;
                    }
                    wardrobe[color][item]++;
                }                
            }

            string[] request = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string askedColor = request[0];
            string askedItem = request[1];

            foreach (var kvp in wardrobe)
            {
                if (kvp.Key == askedColor)
                {
                    Console.WriteLine($"{kvp.Key} clothes:");

                    foreach (var itemKvp in kvp.Value)
                    {
                        if (itemKvp.Key == askedItem)
                        {
                            Console.WriteLine($"* {itemKvp.Key} - {itemKvp.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {itemKvp.Key} - {itemKvp.Value}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{kvp.Key} clothes:");
                    foreach (var itemKvp in kvp.Value)
                    {
                        Console.WriteLine($"* {itemKvp.Key} - {itemKvp.Value}");
                    }
                }
            }
        }
    }
}
