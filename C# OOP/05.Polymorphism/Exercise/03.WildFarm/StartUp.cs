namespace P03.WildFarm
{
    using P03.WildFarm.Animals;
    using P03.WildFarm.Factories;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var animalFactory = new AnimalFactory();
            var foodFactory = new FoodFactory();
            var animals = new List<Animal>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input?.ToLower() == "end")
                {
                    animals.ForEach(a => Console.WriteLine(a));
                    break;
                }

                var animal = animalFactory.Create(input);
                animals.Add(animal);
                var food = foodFactory.Create(Console.ReadLine());
                try
                {
                    animal.Eat(food);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
