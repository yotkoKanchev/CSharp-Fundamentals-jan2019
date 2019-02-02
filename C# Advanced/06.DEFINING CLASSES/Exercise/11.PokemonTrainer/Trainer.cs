using System.Collections.Generic;

namespace _11.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name, int badgesCount, List<Pokemon> pokemons)
        {
            this.Name = name;
            this.NumberOfBadges = badgesCount;
            this.PokemonsList = pokemons;
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> PokemonsList { get; set; } = new List<Pokemon>();       
    }      
}
