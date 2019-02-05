namespace _10._Predicate_Party_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PredicateParty
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<List<string>, string, List<string>> startsWithFunc =
                    (listOfPeople, givenArgument) => listOfPeople.Where(x => x.StartsWith(givenArgument)).ToList();

            Func<List<string>, string, List<string>> endsWithFunc =
                (listOfPeople, givenArgument) => listOfPeople.Where(x => x.EndsWith(givenArgument)).ToList();

            Func<List<string>, string, List<string>> lengthFunc =
                (listOfPeople, givenArgument) => listOfPeople.Where(x => x.Length == int.Parse(givenArgument)).ToList();

            string inputLine = Console.ReadLine();

            while (inputLine != "Party!")
            {
                string[] tokens = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string filter = tokens[1];
                string argument = tokens[2];

                List<string> peopleToRemove = new List<string>();
                List<string> peopleToInsert = new List<string>();
                              
                switch (command)
                {
                    case "Remove":
                        if (filter == "StartsWith")
                        {
                            peopleToRemove.AddRange(startsWithFunc(people, argument));
                        }
                        else if (filter == "EndsWith")
                        {
                            peopleToRemove.AddRange(endsWithFunc(people, argument));
                        }
                        else if (filter == "Length")
                        {
                            peopleToRemove.AddRange(lengthFunc(people, argument));
                        }

                        foreach (var name in peopleToRemove)
                        {
                            people.RemoveAll(x => x == name);
                        }
                        break;
                    case "Double":
                        if (filter == "StartsWith")
                        {
                            peopleToInsert.AddRange(startsWithFunc(people, argument));
                        }
                        else if (filter == "EndsWith")
                        {
                            peopleToInsert.AddRange(endsWithFunc(people, argument));
                        }
                        else if (filter == "Length")
                        {
                            peopleToInsert.AddRange(lengthFunc(people, argument));
                        }

                        foreach (var name in peopleToInsert)
                        {
                            people.Insert(people.IndexOf(name) + 1, name);
                        }
                        break;                 
                }               
                inputLine = Console.ReadLine();
            }
            Console.WriteLine(people.Any() ? $"{string.Join(", ", people)} are going to the party!" : "Nobody is going to the party!");
        }
    }
}
