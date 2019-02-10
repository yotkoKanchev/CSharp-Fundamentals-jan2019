namespace _12.Google
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Google
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            string inputLine = Console.ReadLine();

            while (inputLine?.ToLower() != "end")
            {
                string[] tokens = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = tokens[0];

                if (people.Any(x=>x.Name == personName))
                {
                    Person currentPerson = people.Find(x => x.Name == personName);
                    AddPersonInformation(currentPerson, tokens);                    
                }
                else
                {
                    Person person = new Person(tokens[0]);
                    AddPersonInformation(person, tokens);
                    people.Add(person);
                }               

                inputLine = Console.ReadLine();
            }

            string askedPerson = Console.ReadLine();

            Console.WriteLine(people.FirstOrDefault(x=>x.Name == askedPerson));
        }

        public static void AddPersonInformation(Person currentPerson, string[] tokens)
        {
            if (tokens[1] == "company")
            {
                Company company = new Company(tokens[2], tokens[3], decimal.Parse(tokens[4]));
                currentPerson.Company = company;
            }
            else if (tokens[1] == "car")
            {
                Car car = new Car(tokens[2], int.Parse(tokens[3]));
                currentPerson.Car = car;
            }
            else if (tokens[1] == "pokemon")
            {
                Pokemon pokemon = new Pokemon(tokens[2], tokens[3]);
                currentPerson.AddPokemon(pokemon);
            }
            else if (tokens[1] == "parents")
            {
                Person parent = new Person(tokens[2]);
                parent.DateOfBirth = tokens[3];
                currentPerson.AddParent(parent);
            }
            else if (tokens[1] == "children")
            {
                Person child = new Person(tokens[2]);
                child.DateOfBirth = tokens[3];
                currentPerson.AddChild(child);
            }
        }
    }
}
