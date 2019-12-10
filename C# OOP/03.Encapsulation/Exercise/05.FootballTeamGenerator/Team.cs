namespace P05.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.players = new List<Player>();
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        private int Rating => this.players.Count() == 0
                              ? 0
                              : (int)Math.Round(this.players.Average(p => p.OveralSkillLevel));

        public void AddPlayer(Player player)
        {
            if (!this.players.Any(p => p.Name == player.Name))
            {
                this.players.Add(player);
            }
        }

        public void RemovePlayer(string player)
        {
            var currentPlayer = this.players.FirstOrDefault(p => p.Name == player);

            if (currentPlayer == null)
            {
                throw new ArgumentException($"Player {player} is not in {this.Name} team.");
            }

            this.players.Remove(currentPlayer);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
