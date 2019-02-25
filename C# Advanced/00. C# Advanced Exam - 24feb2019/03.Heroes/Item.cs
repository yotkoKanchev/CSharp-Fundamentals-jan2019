namespace Heroes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Item
    {
        private int strength;
        private int ability;
        private int intelligence;

        public Item(int strength, int ability, int intelligence)
        {
            this.Strength = strength;
            this.Ability = ability;
            this.Intelligence = intelligence;
        }

        public int Strength { get => strength; set => strength = value; }
        public int Ability { get => ability; set => ability = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Item:");
            stringBuilder.AppendLine($"  * Strength: {this.Strength}");
            stringBuilder.AppendLine($"  * Ability: {this.Ability}");
            stringBuilder.Append($"  * Intelligence: {this.Intelligence}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
