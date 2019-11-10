namespace P05.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var teams = new List<Team>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input?.ToLower() == "end")
                {
                    break;
                }

                var args = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                var command = args[0];
                var teamName = args[1];

                try
                {
                    switch (command)
                    {
                        case "Team":
                            if (!teams.Any(t => t.Name == teamName))
                            {
                                teams.Add(new Team(teamName));
                            }

                            break;

                        case "Add":
                            var team = teams.FirstOrDefault(t => t.Name == teamName);

                            if (team == null)
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }

                            var playerName = args[2];
                            var endurance = int.Parse(args[3]);
                            var sprint = int.Parse(args[4]);
                            var dribble = int.Parse(args[5]);
                            var passing = int.Parse(args[6]);
                            var shooting = int.Parse(args[7]);

                            var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                            team.AddPlayer(player);
                            break;

                        case "Remove":
                            var currentTeam = teams.FirstOrDefault(t => t.Name == teamName);
                            if (currentTeam != null)
                            {
                                var playerToRemove = args[2];
                                currentTeam.RemovePlayer(playerToRemove);
                            }

                            break;

                        case "Rating":
                            var askedTeam = teams.FirstOrDefault(t => t.Name == teamName);

                            if (askedTeam == null)
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }

                            Console.WriteLine(askedTeam);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
