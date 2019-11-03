namespace P02_CarsSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class CarSalesman
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Engine engine = CreateEngine(parameters);

                engines.Add(engine);
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Car car = CreateCar(parameters, engines);

                cars.Add(car);
            }

            cars.ForEach(c => Console.WriteLine(c));
        }

        private static Engine CreateEngine(string[] parameters)
        {
            string model = parameters[0];
            int power = int.Parse(parameters[1]);

            Engine engine;

            if (parameters.Length == 3)
            {
                string thirdParameter = parameters[2];
                if (thirdParameter.All(char.IsDigit))
                {
                    int displacement = int.Parse(thirdParameter);
                    engine = new Engine(model, power, displacement);
                }
                else
                {
                    engine = new Engine(model, power, thirdParameter);
                }
            }
            else if (parameters.Length == 4)
            {
                int displacement = int.Parse(parameters[2]);
                string efficiency = parameters[3];
                engine = new Engine(model, power, displacement, efficiency);
            }
            else
            {
                engine = new Engine(model, power);
            }

            return engine;
        }

        private static Car CreateCar(string[] parameters, List<Engine> engines)
        {
            string model = parameters[0];
            string engineModel = parameters[1];
            Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

            Car car;

            if (parameters.Length == 3)
            {
                string thirParameter = parameters[2];

                if (thirParameter.All(char.IsDigit))
                {
                    int weight = int.Parse(thirParameter);
                    car = new Car(model, engine, weight);
                }
                else
                {
                    car = new Car(model, engine, thirParameter);
                }
            }
            else if (parameters.Length == 4)
            {
                int weight = int.Parse(parameters[2]);
                string color = parameters[3];
                car = new Car(model, engine, weight, color);
            }
            else
            {
                car = new Car(model, engine);
            }

            return car;
        }
    }

}
