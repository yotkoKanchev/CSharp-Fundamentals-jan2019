namespace Animals
{
    using Cats;
    using System;
    public class AnimalFactory
    {
        internal IAnimal Create(string animalType, string animalArgs)
        {
            var currentAnimalArgs = animalArgs.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var name = currentAnimalArgs[0];
            var age = int.Parse(currentAnimalArgs[1]);

            string gender;

            switch (animalType)
            {
                case "Cat":
                    gender = currentAnimalArgs[2];
                    return new Cat(name, age, gender);

                case "Dog":
                    gender = currentAnimalArgs[2];
                    return new Dog(name, age, gender);

                case "Frog":
                    gender = currentAnimalArgs[2];
                    return new Frog(name, age, gender);

                case "Kitten":
                    return new Kitten(name, age);

                case "Tomcat":
                    return new Tomcat(name, age);

                default:
                    return null;
            }
        }
    }
}
