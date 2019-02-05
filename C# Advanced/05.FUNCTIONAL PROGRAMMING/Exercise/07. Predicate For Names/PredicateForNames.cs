namespace _07._Predicate_For_Names
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string[], string[]> filteredNames = peopleNames => peopleNames.Where(x => x.Length <= nameLength).ToArray();
            Action<string> print = name => Console.WriteLine(name);

            foreach (var name in filteredNames(names))
            {
                print(name);    
            }
        }
    }
}
