namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var animalFactory = new AnimalFactory();
            var sb = new StringBuilder();

            while (true)
            {
                string animalType = Console.ReadLine();

                if (animalType?.ToLower() == "beast!")
                {
                    break;
                }
                string animalArgs = Console.ReadLine();

                try
                {
                    var animal = animalFactory.Create(animalType, animalArgs);
                    sb.AppendLine(animal.ToString());
                }
                catch (Exception e)
                {
                    sb.AppendLine((e.Message));
                }
            }

            Console.WriteLine(sb);
        }
    }
}
