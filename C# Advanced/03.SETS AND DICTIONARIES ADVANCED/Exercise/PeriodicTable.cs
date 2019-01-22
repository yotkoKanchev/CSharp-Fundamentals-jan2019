namespace _03._Periodic_Table
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PeriodicTable
    {
        static void Main(string[] args)
        {
            SortedSet<string> chemicalCompounds = new SortedSet<string>();

            int compoundsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < compoundsCount; i++)
            {
                string[] currentCompounds = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in currentCompounds)
                {
                    chemicalCompounds.Add(element);
                }                    
            }

            Console.WriteLine(string.Join(" ", chemicalCompounds));
        }
    }
}
