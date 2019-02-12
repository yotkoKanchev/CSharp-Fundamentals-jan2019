using System.Collections.Generic;

namespace _11.PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int badgesCount;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.name = name;
            this.badgesCount = 0;
            this.pokemons = new List<Pokemon>();
        }

        public string Name { get { return this.name; } }
        public int BadgesCount { get { return this.badgesCount; } set { this.badgesCount = value; } }
        public List<Pokemon> Pokemons { get { return this.pokemons; } }

        public void AddPokemon(Pokemon pokemon)
        {
            this.pokemons.Add(pokemon);
        }
    }
}
