namespace VehiclesExtension
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var vehicles = CreateVehicles();

            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                ExecuteCommand(Console.ReadLine(), vehicles);
            }

            vehicles.ForEach(v => Console.WriteLine(v));
        }

        private static void ExecuteCommand(string input, List<Vehicle> vehicles)
        {
            var commandArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var command = commandArgs[0];
            var vehicleType = commandArgs[1];
            var amount = double.Parse(commandArgs[2]);
            var vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

            if (command == "Refuel")
            {
                try
                {
                    vehicle.Refuel(amount);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (command == "Drive")
            {
                Console.WriteLine(vehicle.Drive(amount));
            }
            else if (command == "DriveEmpty")
            {
                Console.WriteLine(((Bus)vehicle).DriveEmpty(amount));
            }
        }

        private static List<Vehicle> CreateVehicles()
        {
            var vehicleFactory = new VehicleFactory();

            return new List<Vehicle>()
            {
                vehicleFactory.Create(Console.ReadLine()),
                vehicleFactory.Create(Console.ReadLine()),
                vehicleFactory.Create(Console.ReadLine()),
            };
        }
    }
}
