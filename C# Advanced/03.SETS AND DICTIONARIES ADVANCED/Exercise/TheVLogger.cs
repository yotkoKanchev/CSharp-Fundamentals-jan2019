namespace _07._The_V_Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TheVLogger
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> vloggers = new Dictionary<string, List<string>>();
            Dictionary<string, int[]> userNumberofFollows = new Dictionary<string, int[]>();
            string inputLine = Console.ReadLine();

            while (inputLine?.ToLower() != "statistics")
            {
                string[] tokens = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string username = tokens[0];
                string command = tokens[1];

                if (command?.ToLower() == "followed")
                {
                    string userToFollow = tokens[2];

                    if (vloggers.ContainsKey(username) && vloggers.ContainsKey(userToFollow))
                    {
                        if (!vloggers[userToFollow].Contains(username) && username != userToFollow)
                        {
                            vloggers[userToFollow].Add(username);
                            userNumberofFollows[userToFollow][0]++;
                            userNumberofFollows[username][1]++;
                        }
                    }
                }
                else if (command?.ToLower() == "joined")
                {
                    if (!vloggers.ContainsKey(username))
                    {
                        vloggers[username] = new List<string>();
                        userNumberofFollows[username] = new int[2];
                    }
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var orderedUsersAndFollowers = userNumberofFollows.OrderByDescending(u => u.Value[0]).ThenBy(u => u.Value[1]).ToDictionary(x=>x.Key,x=>x.Value);

            int counter = 1;
            string userToRemove = "";
            foreach (var kvp in orderedUsersAndFollowers)
            {
                userToRemove = kvp.Key;
                Console.WriteLine($"{counter}. {kvp.Key} : {kvp.Value[0]} followers, {kvp.Value[1]} following");
                counter++;
                if (vloggers[kvp.Key].Count>0)
                {
                    foreach (var item in vloggers[kvp.Key].OrderBy(x=>x))
                    {
                        Console.WriteLine($"*  {item}");                        
                    }
                }
                break;
            }

            orderedUsersAndFollowers.Remove(userToRemove);

            foreach (var kvp in orderedUsersAndFollowers)
            {
                Console.WriteLine($"{counter}. {kvp.Key} : {kvp.Value[0]} followers, {kvp.Value[1]} following");
                counter++;
            }

        }
    }
}
