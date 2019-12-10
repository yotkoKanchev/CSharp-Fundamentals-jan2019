namespace P05.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get => this.name;

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        internal int Endurance
        {
            get => this.endurance;

            set
            {
                ValidateStat(nameof(Endurance), value);

                this.endurance = value;
            }
        }

        internal int Sprint
        {
            get => this.sprint;

            set
            {
                ValidateStat(nameof(Sprint), value);

                this.sprint = value;
            }
        }

        internal int Dribble
        {
            get => this.dribble;

            set
            {
                ValidateStat(nameof(Dribble), value);

                this.dribble = value;
            }
        }

        internal int Passing
        {
            get => this.passing;

            set
            {
                ValidateStat(nameof(Passing), value);

                this.passing = value;
            }
        }

        internal int Shooting
        {
            get => this.shooting;

            set
            {
                ValidateStat(nameof(Shooting), value);

                this.shooting = value;
            }
        }

        private void ValidateStat(string name, int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{name} should be between 0 and 100.");
            }
        }

        internal double OveralSkillLevel => new List<int>()
                                                { this.endurance, this.sprint, this.dribble, this.passing, this.shooting }
                                                .Average();
    }
}
