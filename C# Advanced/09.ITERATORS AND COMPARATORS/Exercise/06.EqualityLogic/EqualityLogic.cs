namespace P06EqualityLogic
{
    using System;
    using System.Collections.Generic;

    public class EqualityLogic
    {
        public static void Main()
        {
            var sortedSet = new SortedSet<Person>();
            var set = new HashSet<Person>();

            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var name = args[0];
                var age = int.Parse(args[1]);

                var person = new Person(name, age);
                sortedSet.Add(person);
                set.Add(person);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(set.Count);
        }
    }
}
