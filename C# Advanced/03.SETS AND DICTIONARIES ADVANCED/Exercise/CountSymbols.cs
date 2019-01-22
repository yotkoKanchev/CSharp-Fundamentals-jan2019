namespace _05._Count_Symbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CountSymbols
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> charsOccurances = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            foreach (var character in text)
            {
                if (!charsOccurances.ContainsKey(character))
                {
                    charsOccurances[character] = 0;
                }

                charsOccurances[character]++;
            }

            foreach (var kvp in charsOccurances)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
