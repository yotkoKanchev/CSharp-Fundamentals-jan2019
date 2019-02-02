namespace CarManufacturer
{
    using CarManufacturer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public class Car
        {
            private string make;
            private string model;
            private int year;
            private double fuelQuantity;
            private double fuelConsumption;
            private Engine engine;
            private Tire[] tires;

            public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
                : this(make, model, year, fuelQuantity, fuelConsumption)
            {
                this.Engine = engine;
                this.Tires = tires;
            }

            public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
                : this(make, model, year)
            {
                this.FuelQuantity = fuelQuantity;
                this.FuelConsumption = fuelConsumption;
            }
            public Car(string make, string model, int year)
                : this()
            {
                this.Make = make;
                this.Model = model;
                this.Year = year;
            }

            public Car()
            {
                this.Make = "VW";
                this.Model = "Golf";
                this.Year = 2025;
                this.FuelQuantity = 200;
                this.FuelConsumption = 10;
            }

            public string Make
            {
                get { return this.make; }
                set { this.make = value; }
            }

            public string Model
            {
                get { return this.model; }
                set { this.model = value; }
            }

            public int Year
            {
                get { return this.year; }
                set { this.year = value; }
            }

            public double FuelQuantity
            {
                get { return this.fuelQuantity; }
                set { this.fuelQuantity = value; }
            }

            public double FuelConsumption
            {
                get { return this.fuelConsumption; }
                set { this.fuelConsumption = value; }
            }

            public Engine Engine
            {
                get { return this.engine; }
                set { this.engine = value; }
            }

            public Tire[] Tires
            {
                get { return this.tires; }
                set { this.tires = value; }
            }

            public void Drive(double distance)
            {
                var consumedFuel = distance * (this.fuelConsumption / 100);

                if (this.fuelQuantity - consumedFuel >= 0)
                {
                    this.fuelQuantity -= consumedFuel;
                }
                else
                {
                    Console.WriteLine("Not enough fuel to perform this trip!");
                }
            }

            public string WhoAmI()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Make: {this.make}");
                sb.AppendLine($"Model: {this.model}");
                sb.AppendLine($"Year: {this.year}");
                sb.Append($"Fuel: {this.fuelQuantity:f2}L");
                return sb.ToString();
            }
        }

        public class Engine
        {
            private int horsePower;
            private double cubicCapacity;

            public Engine(int horsePower, double cubicCapacity)
            {
                this.HorsePower = horsePower;
                this.CubicCapacity = cubicCapacity;
            }

            public int HorsePower
            {
                get { return this.horsePower; }
                set { this.horsePower = value; }
            }

            public double CubicCapacity
            {
                get { return this.cubicCapacity; }
                set { this.cubicCapacity = value; }
            }

        }

        public class Tire
        {
            private int year;
            private double pressure;

            public Tire(int year, double pressure)
            {
                this.Year = year;
                this.Pressure = pressure;
            }

            public int Year
            {
                get { return this.year; }
                set { this.year = value; }
            }

            public double Pressure
            {
                get { return this.pressure; }
                set { this.pressure = value; }
            }
        }

        public static void Main()
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string inputLine = Console.ReadLine();

            while (inputLine != "No more tires")
            {
                string[] tiresTokens = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Tire tire1 = new Tire(int.Parse(tiresTokens[0]), double.Parse(tiresTokens[1]));
                Tire tire2 = new Tire(int.Parse(tiresTokens[2]), double.Parse(tiresTokens[3]));
                Tire tire3 = new Tire(int.Parse(tiresTokens[4]), double.Parse(tiresTokens[5]));
                Tire tire4 = new Tire(int.Parse(tiresTokens[6]), double.Parse(tiresTokens[7]));

                var tiresSet = new Tire[4]
                {
                tire1,
                tire2,
                tire3,
                tire4,
                };

                tires.Add(tiresSet);

                inputLine = Console.ReadLine();
            }

            inputLine = Console.ReadLine();

            while (inputLine != "Engines done")
            {
                string[] engineTokens = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(engineTokens[0]);
                double cubicCapacity = double.Parse(engineTokens[1]);

                Engine currentEngine = new Engine(horsePower, cubicCapacity);
                engines.Add(currentEngine);

                inputLine = Console.ReadLine();
            }

            inputLine = Console.ReadLine();

            while (inputLine != "Show special")
            {
                string[] tokens = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currentMake = tokens[0];
                string currentModel = tokens[1];
                int currentYear = int.Parse(tokens[2]);
                double currentQuanity = double.Parse(tokens[3]);
                double currentConsumtion = double.Parse(tokens[4]);

                int askedTiresSet = int.Parse(tokens[5]);
                int askedEngine = int.Parse(tokens[6]);

                Car car = new Car(currentMake, currentModel, currentYear, currentQuanity, currentConsumtion, engines[askedEngine], tires[askedTiresSet]);

                cars.Add(car);
                inputLine = Console.ReadLine();
            }

            var filteredCars = cars.FindAll(x => x.Year >= 2017 && x.Engine.HorsePower > 330
            && x.Tires.Select(y => y.Pressure).Sum() > 9 && x.Tires.Select(y => y.Pressure).Sum() < 10).ToList();

            for (int i = 0; i < filteredCars.Count; i++)
            {
                filteredCars[i].Drive(20);
            }

            foreach (var specialCar in filteredCars)
            {
                Console.WriteLine($"Make: {specialCar.Make}");
                Console.WriteLine($"Model: {specialCar.Model}");
                Console.WriteLine($"Year: {specialCar.Year}");
                Console.WriteLine($"HorsePowers: {specialCar.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {specialCar.FuelQuantity}");
            }
        }
    }
}
