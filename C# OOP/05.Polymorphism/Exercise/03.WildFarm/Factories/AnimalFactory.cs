namespace P03.WildFarm.Factories
{
    using System;
    using P03.WildFarm.Animals;
    using P03.WildFarm.Animals.Birds;
    using P03.WildFarm.Animals.Mammals;
    using P03.WildFarm.Animals.Mammals.Felines;

    public class AnimalFactory
    {
        public Animal Create(string input)
        {
            var animalArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var type = animalArgs[0];
            var name = animalArgs[1];
            var weight = double.Parse(animalArgs[2]);

            Animal animal;

            switch (type)
            {
                case "Cat":
                    var livingRegion = animalArgs[3];
                    var breed = animalArgs[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                    break;
                case "Tiger":
                    livingRegion = animalArgs[3];
                    breed = animalArgs[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                    break;
                case "Owl":
                    var wingSize = double.Parse(animalArgs[3]);
                    animal = new Owl(name, weight, wingSize);
                    break;
                case "Hen":
                    wingSize = double.Parse(animalArgs[3]);
                    animal = new Hen(name, weight, wingSize);
                    break;
                case "Dog":
                    livingRegion = animalArgs[3];
                    animal = new Dog(name, weight, livingRegion);
                    break;             
                case "Mouse":
                    livingRegion = animalArgs[3];
                    animal = new Mouse(name, weight, livingRegion);
                    break;
                default:
                    return null;
            }

            return animal;
        }
    }
}
