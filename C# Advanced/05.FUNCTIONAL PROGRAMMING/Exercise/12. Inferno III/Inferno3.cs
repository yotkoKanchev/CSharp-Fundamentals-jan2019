namespace _12._Inferno_III
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Inferno3
    {
        static void Main(string[] args)
        {
            Action<List<int>> print = p => Console.WriteLine(string.Join(" ",p));

            var filters = new Dictionary<string, Dictionary<int, Func<int, int, bool>>>();

            List<int> numbers = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string inputLine = Console.ReadLine();

            while (inputLine != "Forge")
            {
                string[] tokens = inputLine.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string functionalName = tokens[1];
                int value = int.Parse(tokens[2]);

                Func<int, int, bool> sumFunc = GetFunction(numbers, functionalName);

                if (command == "Exclude")
                {
                    if (filters.ContainsKey(functionalName) == false)
                    {
                        filters.Add(functionalName, new Dictionary<int, Func<int, int, bool>>());
                    }

                    if (filters[functionalName].ContainsKey(value) == false)
                    {
                        filters[functionalName].Add(value, sumFunc);
                    }
                }
                else
                {
                    if (filters.ContainsKey(functionalName))
                    {
                        filters[functionalName].Remove(value);
                    }
                }
                
                inputLine = Console.ReadLine();
            }

            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                bool isValid = true;

                foreach (var filter in filters)
                {
                    foreach (var kvp in filter.Value)
                    {
                        if (kvp.Value(i, kvp.Key))
                        {
                            isValid = false;
                            break;
                        }
                    }
                }

                if (isValid)
                {
                    result.Add(numbers[i]);
                }
            }

            print(result);
        }

        private static Func<int, int, bool> GetFunction(List<int> numbers, string functionalName)
        {
            if (functionalName == "Sum Left")
            {
                return (a, b) => a == 0 ? numbers[a] == b : numbers[a] + numbers[a - 1] == b;
            }
            else if (functionalName == "Sum Right")
            {
                return (a, b) => a == numbers.Count-1 ? numbers[a] == b : numbers[a] + numbers[a + 1] == b;
            }
            else if (functionalName == "Sum Left Right")
            {
                return (a, b) => numbers.Count == 1 ? numbers[a] == b :
                                 a == numbers.Count - 1 ? numbers[a - 1] + numbers[a] == b :
                                 a == 0 ? numbers[a] + numbers[a + 1] == b :
                                 numbers[a - 1] + numbers[a] + numbers[a + 1] == b;
            }

            return null;
        }
    }
}
