namespace _11.PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PokemonTrainer
    {
        static void Main(string[] args)
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            List<Trainer> trainers = new List<Trainer>();

            string inputLine = Console.ReadLine();

            while (inputLine?.ToLower() != "tournament")
            {
                string[] tokens = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                bool trainerExist = false;

                foreach (var trainer in trainers)
                {
                    if (trainer.Name == trainerName)
                    {
                        trainerExist = true;
                        trainers.Find(x => x.Name == trainerName).PokemonsList.Add(pokemon);
                        break;
                    }
                }

                if (trainerExist == false)
                {
                    List<Pokemon> currentPokList = new List<Pokemon>();
                    currentPokList.Add(pokemon);
                    Trainer trainer = new Trainer(trainerName, 0, currentPokList);
                    trainers.Add(trainer);
                }
                inputLine = Console.ReadLine();
            }

            string askedElement = Console.ReadLine();

            while (askedElement?.ToLower() != "end")
            {
                trainers = CheckElementExist(askedElement, trainers);

                askedElement = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(x=>x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.PokemonsList.Count()}");
            }
        }

        public static List<Trainer> CheckElementExist(string element, List<Trainer> trainers)
        {
            foreach (var currentTrainer in trainers)
            {
                bool exist = false;

                foreach (var pokemon in currentTrainer.PokemonsList)
                {
                    if (pokemon.Element == element)
                    {
                        exist = true;
                        currentTrainer.NumberOfBadges += 1;
                        break;
                    }
                }
                List<Pokemon> pokemonsToRemove = new List<Pokemon>();

                if (exist == false)
                {
                    foreach (var pokemon in currentTrainer.PokemonsList)
                    {
                        pokemon.Health -= 10;
                        if (pokemon.Health <= 0)
                        {
                            pokemonsToRemove.Add(pokemon);
                        }
                    }
                }

                foreach (var pokemon in pokemonsToRemove)
                {
                    currentTrainer.PokemonsList.Remove(pokemon);
                }
            }
            return trainers;
        }
    }
}
