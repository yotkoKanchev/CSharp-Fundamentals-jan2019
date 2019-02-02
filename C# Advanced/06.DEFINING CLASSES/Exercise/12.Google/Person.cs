using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.Google
{
    public class Person
    {
        public Person(string name)
        {
            this.Name = name;            
        }

        public string Name { get; set; }
        public Company PersonCompany { get; set; } = new Company(string.Empty, string.Empty, 0);
        public Car PersonCar { get; set; } = new Car(string.Empty, 0);
        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
        public List<Parent> Parents { get; set; } = new List<Parent>();
        public List<Child> Children { get; set; } = new List<Child>();

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{this.Name}");
            stringBuilder.AppendLine(this.PersonCompany.ToString());
            stringBuilder.AppendLine(this.PersonCar.ToString());

            stringBuilder.AppendLine($"Pokemon:");
            if (this.Pokemons.Any())
            {
                foreach (var pokemon in this.Pokemons)
                {
                    stringBuilder.AppendLine($"{pokemon.Name} {pokemon.Type}");
                }
            }

            stringBuilder.AppendLine($"Parents:");
            if (this.Parents.Any())
            {
                foreach (var parent in this.Parents)
                {
                    stringBuilder.AppendLine($"{parent.Name} {parent.Birthday}");
                }
            }

            stringBuilder.AppendLine($"Children:");
            if (this.Children.Any())
            {
                foreach (var child in this.Children)
                {
                    stringBuilder.AppendLine($"{child.Name} {child.Birthday}");
                }
            }

            return stringBuilder.ToString();
        }
    }
}
