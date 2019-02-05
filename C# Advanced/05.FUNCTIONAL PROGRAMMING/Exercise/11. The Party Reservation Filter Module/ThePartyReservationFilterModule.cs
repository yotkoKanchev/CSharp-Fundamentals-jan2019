namespace _11._The_Party_Reservation_Filter_Module
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ThePartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            HashSet<KeyValuePair<string, string>> filtersAndArguments = new HashSet<KeyValuePair<string, string>>();
            string inputLine = Console.ReadLine();

            while (inputLine != "Print")
            {
                string[] tokens = inputLine.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string filter = tokens[1];
                string argument = tokens[2];

                if (command == "Add filter")
                {
                    var kvp = new KeyValuePair<string, string>(filter, argument);
                    filtersAndArguments.Add(kvp);
                }
                else if (command == "Remove filter")
                {
                    var kvp = new KeyValuePair<string, string>(filter, argument);
                    filtersAndArguments.Remove(kvp);
                }

                inputLine = Console.ReadLine();
            }

            Func<List<string>, string, List<string>> startsWithFunc =
                (listOfPeople, parameter) => listOfPeople.Where(x => x.StartsWith(parameter)).ToList();
            Func<List<string>, string, List<string>> endsWithFunc =
                (listOfPeople, parameter) => listOfPeople.Where(x => x.EndsWith(parameter)).ToList();
            Func<List<string>, string, List<string>> lengthFunc =
                (listOfPeople, parameter) => listOfPeople.Where(x => x.Length == int.Parse(parameter)).ToList();
            Func<List<string>, string, List<string>> containsFunc =
                (listOfPeople, parameter) => listOfPeople.Where(x => x.Contains(parameter)).ToList();
            List<string> peopleToRemove = new List<string>();
            foreach (var kvp in filtersAndArguments)
            {
                string filter = kvp.Key;
                string parameter = kvp.Value;

                switch (filter)
                {
                    case "Starts with":
                        peopleToRemove.AddRange(startsWithFunc(names, parameter));
                        break;
                    case "Ends with":
                        peopleToRemove.AddRange(endsWithFunc(names, parameter));
                        break;
                    case "Length":
                        peopleToRemove.AddRange(lengthFunc(names, parameter));
                        break;
                    case "Contains":
                        peopleToRemove.AddRange(containsFunc(names, parameter));
                        break;
                }                
            }
            foreach (var name in peopleToRemove)
            {
                names.RemoveAll(x => x == name);
            }

            Console.WriteLine(string.Join(" ",names));
        }
    }
}
