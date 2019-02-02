namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>(); 
            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(name,age);
                people.Add(person);
            }

            foreach (var person in people.OrderBy(x=>x.Name).Where(x=>x.Age > 30))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
