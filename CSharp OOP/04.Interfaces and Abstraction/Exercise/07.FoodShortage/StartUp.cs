namespace P07.FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var personFactory = new PersonFactory();

            var people = new List<Person>();

            var peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                var personArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                people.Add(personFactory.Create(personArgs));
            }

            while (true)
            {
                var name = Console.ReadLine();

                if (name?.ToLower() == "end")
                {
                    Console.WriteLine(people.Sum(p => p.Food));
                    break;
                }

                var person = people.FirstOrDefault(p => p.Name == name);

                if (person != null)
                {
                    person.BuyFood();
                }
            }
        }
    }
}
