namespace _11.PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PokemonTrainer
    {
        public static void Main()
        {
            List<Trainer> trainers = new List<Trainer>();
            string inputLine = Console.ReadLine();

            while (inputLine?.ToLower() != "tournament")
            {
                string[] tokens = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string element = tokens[2];
                int health = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, element, health);

                if (trainers.Any(x => x.Name == trainerName))
                {
                    trainers.Find(x => x.Name == trainerName).AddPokemon(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.AddPokemon(pokemon);
                    trainers.Add(trainer);
                }

                inputLine = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command?.ToLower() != "end")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == command))
                    {
                        trainer.BadgesCount++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)                       
                        {
                            trainer.Pokemons[i].Health -= 10;
                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.Remove(trainer.Pokemons[i]);
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(x=>x.BadgesCount))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.Pokemons.Count}");
            }
        }
    }
}
