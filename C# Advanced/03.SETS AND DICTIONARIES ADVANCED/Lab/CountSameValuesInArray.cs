namespace _01._Count_Same_Values_in_Array
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CountSameValuesInArray
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var numbersOccurances = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!numbersOccurances.ContainsKey(number))
                {
                    numbersOccurances[number] = 0;
                }
                numbersOccurances[number]++;
            }

            foreach (var kvp in numbersOccurances)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
