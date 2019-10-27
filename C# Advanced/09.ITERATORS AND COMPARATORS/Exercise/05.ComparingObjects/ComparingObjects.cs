namespace P05ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ComparingObjects
    {
        public static void Main()
        {
            var people = new List<Person>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input?.ToLower() == "end")
                {
                    break;
                }

                var args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var name = args[0];
                var age = int.Parse(args[1]);
                var town = args[2];

                var person = new Person(name, age, town);
                people.Add(person);
            }

            var personNumber = int.Parse(Console.ReadLine()) - 1;

            var currentPerson = people[personNumber];

            var matches = people.Where(x => x.CompareTo(currentPerson) == 0).Count();
            var totalPeople = people.Count;
            if (matches - 1 == 0)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {totalPeople - matches} {totalPeople}");
            }
        }
    }
}
