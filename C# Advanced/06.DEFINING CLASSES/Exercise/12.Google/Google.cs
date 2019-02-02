namespace _12.Google
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Google
    {
        static void Main()
        {
            List<Person> people = new List<Person>();

            string inputLine = Console.ReadLine();

            while (inputLine?.ToLower() != "end")
            {
                string[] personTokens = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = personTokens[0];
                string personDetail = personTokens[1];

                if (people.Any(x=>x.Name == personName))
                {
                    switch (personDetail)
                    {
                        case "company":
                            string companyName = personTokens[2];
                            string department = personTokens[3];
                            decimal salary = decimal.Parse(personTokens[4]);

                            Company company = new Company(companyName, department, salary);
                            people.Find(x=>x.Name == personName).PersonCompany = company;
                            break;

                        case "pokemon":
                            string pokemonName = personTokens[2];
                            string type = personTokens[3];

                            Pokemon pokemon = new Pokemon(pokemonName, type);
                            people.Find(x => x.Name == personName).Pokemons.Add(pokemon);
                            break;

                        case "parents":
                            string parentName = personTokens[2];
                            string parentBirthday = personTokens[3];

                            Parent parent = new Parent(parentName, parentBirthday);
                            people.Find(x => x.Name == personName).Parents.Add(parent);
                            break;

                        case "children":
                            string childName = personTokens[2];
                            string childBirthday = personTokens[3];

                            Child child = new Child(childName, childBirthday);
                            people.Find(x => x.Name == personName).Children.Add(child);
                            break;

                        case "car":
                            string model = personTokens[2];
                            double speed = double.Parse(personTokens[3]);

                            Car car = new Car(model, speed);
                            people.Find(x => x.Name == personName).PersonCar = car;
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    Person person = new Person(personName);
                    switch (personDetail)
                    {
                        case "company":
                            string companyName = personTokens[2];
                            string department = personTokens[3];
                            decimal salary = decimal.Parse(personTokens[4]);

                            Company company = new Company(companyName, department, salary);
                            person.PersonCompany = company;
                            break;

                        case "pokemon":
                            string pokemonName = personTokens[2];
                            string type = personTokens[3];

                            Pokemon pokemon = new Pokemon(pokemonName, type);
                            person.Pokemons.Add(pokemon);
                            break;

                        case "parents":
                            string parentName = personTokens[2];
                            string parentBirthday = personTokens[3];

                            Parent parent = new Parent(parentName, parentBirthday);
                            person.Parents.Add(parent);
                            break;

                        case "children":
                            string childName = personTokens[2];
                            string childBirthday = personTokens[3];

                            Child child = new Child(childName, childBirthday);
                            person.Children.Add(child);
                            break;

                        case "car":
                            string model = personTokens[2];
                            double speed = double.Parse(personTokens[3]);

                            Car car = new Car(model, speed);
                            person.PersonCar = car;
                            break;

                        default:
                            break;
                    }

                    people.Add(person);
                }

                inputLine = Console.ReadLine();
            }

            string askedPersonName = Console.ReadLine();

            Person askedPerson = people.Find(x => x.Name == askedPersonName);

            Console.WriteLine(askedPerson);
            //Console.WriteLine("Company:");
            //if (askedPerson.PersonCompany.Name != null)
            //{
            //    Console.WriteLine($"{askedPerson.PersonCompany.Name} {askedPerson.PersonCompany.Department} {askedPerson.PersonCompany.Salary:f2}");
            //}

        }
    }
}
