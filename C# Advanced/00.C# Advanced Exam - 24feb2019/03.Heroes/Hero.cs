namespace Heroes
{
    using System.Text;

    public class Hero
    {
        private string name;
        private int level;
        private Item item;

        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public string Name { get => name; set => name = value; }
        public int Level { get => level; set => level = value; }
        public Item Item { get => item; set => item = value; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Hero: {this.Name} – {this.Level}lvl");
            stringBuilder.AppendLine($"Item:");
            stringBuilder.Append(this.Item.ToString());

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
