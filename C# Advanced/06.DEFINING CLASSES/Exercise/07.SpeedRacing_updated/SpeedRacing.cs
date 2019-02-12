namespace _07.SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SpeedRacing
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] carsData = Console.ReadLine().Split();
                string model = carsData[0];
                double fuelAmount = double.Parse(carsData[1]);
                double fuelConsumption = double.Parse(carsData[2]);

                Car car = new Car(model, fuelAmount, fuelConsumption);

                cars.Add(car);
            }

            string inputLine = Console.ReadLine();

            while (inputLine?.ToLower() != "end")
            {
                string[] askedCarData = inputLine.Split();
                string askedModel = askedCarData[1];
                int distanceToTravel = int.Parse(askedCarData[2]);

                cars.First(x => x.Model == askedModel).Drive(distanceToTravel);

                inputLine = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
