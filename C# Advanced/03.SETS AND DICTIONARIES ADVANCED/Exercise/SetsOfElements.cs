namespace _02._Sets_of_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SetsOfElements
    {
        static void Main(string[] args)
        {
            int[] setsLength = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            List<int> resultList = new List<int>();

            int firstSetLength = setsLength[0];
            int secondSetLength = setsLength[1];

            for (int i = 0; i < firstSetLength; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < secondSetLength; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));

            }

            foreach (var num in firstSet)
            {
                foreach (var number in secondSet)
                {
                    if (num == number)
                    {
                        resultList.Add(num);
                    }
                }
            }

            Console.WriteLine(string.Join(" ",resultList));
        }
    }
}
