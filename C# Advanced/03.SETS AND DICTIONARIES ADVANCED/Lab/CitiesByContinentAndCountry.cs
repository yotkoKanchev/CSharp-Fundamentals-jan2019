namespace _04._Cities_by_Continent_and_Country
{
    using System;
    using System.Collections.Generic;

    class CitiesByContinentAndCountry
    {
        static void Main(string[] args)
        {
            var citiesCatalog = new Dictionary<string, Dictionary<string, List<string>>>();

            int inputLinesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLinesCount; i++)
            {
                string[] cityArguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = cityArguments[0];
                string country = cityArguments[1];
                string town = cityArguments[2];

                if (!citiesCatalog.ContainsKey(continent))
                {
                    citiesCatalog[continent] = new Dictionary<string, List<string>>();
                }

                if (!citiesCatalog[continent].ContainsKey(country))
                {
                    citiesCatalog[continent][country] = new List<string>();
                }

                citiesCatalog[continent][country].Add(town);
            }

            foreach (var kvp in citiesCatalog)
            {
                Console.WriteLine($"{kvp.Key}:");

                foreach (var pair in kvp.Value)
                {
                    Console.WriteLine($"  {pair.Key} -> {string.Join(", ",pair.Value)}");
                }
            }
        }
    }
}
