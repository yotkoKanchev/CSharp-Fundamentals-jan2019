namespace P01RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using P01RawData.Factories;
    using P01RawData.Models;

    public class RawData
    {
        public static void Main()
        {
            var carFactory = new CarFactory();
            int linesCount = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (int i = 0; i < linesCount; i++)
            {
                var args = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var car = carFactory.Create(args);

                cars.Add(car);
            }

            var sortingCaroType = Console.ReadLine();

            var result = SortCars(cars, sortingCaroType);

            result?.ForEach(c => Console.WriteLine(c));
        }

        private static List<Car> SortCars(List<Car> cars, string cargoType)
        {
            List<Car> result = null;

            if (cargoType == "fragile")
            {
                result = cars.Where(c => c.Cargo.Type == cargoType && c.Tires.Any(t => t.Pressure < 1)).ToList();
            }
            else if (cargoType == "flamable")
            {
                result = cars.Where(c => c.Cargo.Type == cargoType && c.Engine.Power > 250).ToList();
            }

            return result;
        }
    }
}
