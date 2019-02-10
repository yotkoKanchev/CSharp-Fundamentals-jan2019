using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.Google
{
    public class Person
    {
        private string name;
        private string birthDay;
        private Car car;
        private Company company;
        private List<Pokemon> pokemons = new List<Pokemon>();
        private List<Person> parents = new List<Person>();
        private List<Person> children = new List<Person>();
                
        public Person(string name)
        {
            this.name = name;
        }

        public Car Car { get { return this.car; } set { this.car = value; } }
        public Company Company { get { return this.company; } set { this.company = value; } }
        public string Name { get { return this.name; } }
        public string DateOfBirth { get { return this.birthDay; } set { this.birthDay = value; } }

        public void AddPokemon(Pokemon pokemon)
        {
            this.pokemons.Add(pokemon);
        }

        public void AddChild(Person child)
        {
            this.children.Add(child);
        }

        public void AddParent(Person parent)
        {
            this.parents.Add(parent);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name}");
            sb.AppendLine($"Company:");
            if (this.Company != null)
            {
                sb.AppendLine(this.Company.ToString());
            }
            sb.AppendLine($"Car:");
            if (this.Car != null)
            {
                sb.AppendLine(this.Car.ToString());
            }
            sb.AppendLine($"Pokemon:");            
            if (this.pokemons.Any())
            {
                foreach (var pokemon in this.pokemons)
                {
                    sb.AppendLine(pokemon.ToString());
                }
            }
            sb.AppendLine($"Parents:");
            if (this.parents.Any())
            {
                foreach (var parent in this.parents)
                {
                    sb.AppendLine($"{parent.Name} {parent.birthDay}");
                }
            }
            sb.AppendLine($"Children:");
            if (this.children.Any())
            {
                foreach (var child in this.children)
                {
                    sb.AppendLine($"{child.Name} {child.birthDay}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
