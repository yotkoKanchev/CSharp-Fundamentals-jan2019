namespace P04.PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using static Modifier.Flour;
    using static Modifier.BakingType;

    public class Dough : Ingredient
    {
        private int weight;
        private string flour;
        private string bakingType;
        private List<string> validFlourTypes = new List<string>() { "white", "wholegrain" };
        private List<string> validBakingTypes = new List<string>() { "crispy", "chewy", "homemade" };

        public Dough(int weight, string flour, string bakingType)
        {
            this.Flour = flour.ToLower();
            this.BakingType = bakingType.ToLower();
            this.Weight = weight;
        }

        private string Flour
        {
            get => this.flour;

            set
            {
                if (!this.validFlourTypes.Contains(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flour = value;
            }
        }

        private string BakingType
        {
            get => this.bakingType;

            set
            {
                if (!this.validBakingTypes.Contains(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingType = value;
            }
        }

        internal override int Weight
        {
            get => this.weight;

            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        internal override double CaloriesModifier()
        {
            double flourModifier = 0;
            double bakingTypeModifier = 0;

            if (this.Flour == "white")
            {
                flourModifier = White;
            }
            else if (this.Flour == "wholegrain")
            {
                flourModifier = Wholegrain;
            }

            if (this.BakingType == "crispy")
            {
                bakingTypeModifier = Crispy;
            }
            else if (this.bakingType == "chewy")
            {
                bakingTypeModifier = Chewy;
            }
            else if (this.bakingType == "homemade")
            {
                bakingTypeModifier = Homemade;
            }

            return flourModifier * bakingTypeModifier;

        }
    }
}
