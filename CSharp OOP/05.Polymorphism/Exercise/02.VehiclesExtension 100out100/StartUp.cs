namespace VehiclesExtension
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            double[] carArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(double.Parse)
                .ToArray();

            Car car = new Car(carArgs[0], carArgs[1], carArgs[2]);

            double[] truckArgs = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Skip(1)
               .Select(double.Parse)
               .ToArray();

            Truck truck = new Truck(truckArgs[0], truckArgs[1], truckArgs[2]);

            double[] busArgs = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Skip(1)
               .Select(double.Parse)
               .ToArray();

            Bus bus = new Bus(busArgs[0], busArgs[1], busArgs[2]);

            vehicles.Add(car);
            vehicles.Add(truck);
            vehicles.Add(bus);

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0];
                string vechicleType = commandArgs[1];
                double amount = double.Parse(commandArgs[2]);

                if (command == "Drive")
                {
                    foreach (var vehicle in vehicles.Where(x => x.GetType().Name == vechicleType))
                    {
                        Console.WriteLine(vehicle.Drive(amount));
                    }
                }
                else if (command == "Refuel")
                {
                    try
                    {
                        foreach (var vehicle in vehicles.Where(x => x.GetType().Name == vechicleType))
                        {
                            vehicle.Refuel(amount);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "DriveEmpty")
                {
                    foreach (var vehicle in vehicles.Where(x => x.GetType().Name == vechicleType))
                    {
                        ((Bus)vehicle).DriveEmpty(amount);
                    }
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
