namespace _08.RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RawData
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] carData = Console.ReadLine().Split();
                string model = carData[0];
                int engineSpeed = int.Parse(carData[1]);
                int enginePower = int.Parse(carData[2]);
                int cargoWeight = int.Parse(carData[3]);
                string cargoType = carData[4];
                string[] tiresData = new string[8];

                Array.Copy(carData,5, tiresData,0,8);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                TiresSet tiresSet = new TiresSet(tiresData);

                Car car = new Car(model, engine, cargo, tiresSet);
                cars.Add(car);
            }

            string askedCargoType = Console.ReadLine();

            if (askedCargoType == "fragile")
            {
                foreach (var car in cars.Where(x => x.Cargo.CargoType == askedCargoType && x.TiresSet.Tires.Any(y => y.TirePressure < 1)))
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                foreach (var car in cars.Where(x => x.Cargo.CargoType == askedCargoType && x.Engine.EnginePower > 250))
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
