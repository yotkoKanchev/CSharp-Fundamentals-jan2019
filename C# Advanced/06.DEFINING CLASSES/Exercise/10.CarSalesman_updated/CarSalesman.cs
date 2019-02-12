namespace _10.CarSalesman
{
    using System;
    using System.Collections.Generic;

    public class CarSalesman
    {
        public static void Main()
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                string[] engineData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = engineData[0];
                int horsePowers = int.Parse(engineData[1]);
                int displacement;
                string efficiency;

                Engine engine = null;
                if (engineData.Length == 4)
                {
                    displacement = int.Parse(engineData[2]);
                    efficiency = engineData[3];
                    engine = new Engine(model, horsePowers, displacement, efficiency);
                }
                else if (engineData.Length == 3)
                {
                    if (char.IsDigit(engineData[2][0]))
                    {
                        displacement = int.Parse(engineData[2]);
                        engine = new Engine(model, horsePowers, displacement);
                    }
                    else
                    {
                        efficiency = engineData[2];
                        engine = new Engine(model, horsePowers, efficiency);
                    }
                }
                else
                {
                    engine = new Engine(model, horsePowers);
                }

                engines.Add(engine);
            }

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];
                string engineModel = carData[1];
                int weight;
                string color;

                Car car = null;
                if (carData.Length == 4)
                {
                    weight = int.Parse(carData[2]);
                    color = carData[3];
                    car = new Car(model, engines.Find(e=>e.EngineModel==engineModel), weight, color);
                }
                else if (carData.Length == 3)
                {
                    if (char.IsDigit(carData[2][0]))
                    {
                        weight = int.Parse(carData[2]);
                        car = new Car(model, engines.Find(e=>e.EngineModel == engineModel), weight);
                    }
                    else
                    {
                        color = carData[2];
                        car = new Car(model, engines.Find(e => e.EngineModel == engineModel), color);
                    }
                }
                else
                {
                    car = new Car(model, engines.Find(e => e.EngineModel == engineModel));
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
