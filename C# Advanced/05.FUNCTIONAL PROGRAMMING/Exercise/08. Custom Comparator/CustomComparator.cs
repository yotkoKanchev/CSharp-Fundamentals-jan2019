namespace _08._Custom_Comparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CustomComparator
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(x => x % 2 != 0)
                .ThenBy(x => x)
                .ToList()
                .ForEach(x => Console.Write(x + " "));

        }
    }
}
