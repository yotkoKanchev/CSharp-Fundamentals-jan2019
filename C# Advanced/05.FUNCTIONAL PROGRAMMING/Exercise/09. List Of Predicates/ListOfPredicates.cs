namespace _09._List_Of_Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> resultList = new List<int>();

            Func<int, int, bool> checker = (number, divider) => number % divider != 0;

            for (int i = 1; i <= n; i++)
            {
                bool isDivisable = true;

                foreach (var num in dividers)
                {                  
                    if (checker(i, num))
                    {
                        isDivisable = false;
                        break;
                    }
                }

                if (isDivisable)
                {
                    resultList.Add(i);
                }
            }

            Action<List<int>> print = resultNumbers => Console.WriteLine(string.Join(" ", resultNumbers));

            print(resultList);
        }
    }
}
