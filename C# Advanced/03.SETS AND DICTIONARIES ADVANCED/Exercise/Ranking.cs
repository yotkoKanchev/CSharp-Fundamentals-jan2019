namespace _08._Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestAndPassword = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();
            string inputLine = Console.ReadLine();

            while (inputLine?.ToLower() != "end of contests")
            {
                string[] tokens = inputLine.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];
                contestAndPassword.Add(contest, password);

                inputLine = Console.ReadLine();
            }

            inputLine = Console.ReadLine();

            while (inputLine?.ToLower() != "end of submissions")
            {
                string[] tokens = inputLine.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string askedContest = tokens[0];
                string askedPassword = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (contestAndPassword.ContainsKey(askedContest) && contestAndPassword[askedContest] == askedPassword)
                {
                    if (!users.ContainsKey(username))
                    {
                        users[username] = new Dictionary<string, int>();
                    }

                    if (!users[username].ContainsKey(askedContest) || users[username][askedContest] < points)
                    {
                        users[username][askedContest] = points;
                    }
                }

                inputLine = Console.ReadLine();
            }

            foreach (var kvp in users.OrderByDescending(x=>x.Value.Values.Sum()))
            {
                Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value.Values.Sum()} points.");
                break;
            }

            Console.WriteLine("Ranking:");

            foreach (var kvp in users.OrderBy(x=>x.Key))
            {
                Console.WriteLine(kvp.Key);
                foreach (var item in kvp.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
