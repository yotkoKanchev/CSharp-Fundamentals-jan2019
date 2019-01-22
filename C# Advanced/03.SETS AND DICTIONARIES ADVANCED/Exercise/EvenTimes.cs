namespace _04._Even_Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EvenTimes
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int numbersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersCount; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(currentNumber))
                {
                    numbers[currentNumber] = 0;
                }

                numbers[currentNumber]++;
            }

            foreach (var kvp in numbers.Where(n=>n.Value % 2 == 0))
            {
                Console.WriteLine(kvp.Key);
            }
        }
    }
}
