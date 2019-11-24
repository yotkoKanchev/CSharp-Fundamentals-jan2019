namespace P02.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var vehicleFactory = new VehicleFactory();

            var vehicles = new List<Vehicle>();

            var car = vehicleFactory.Create(Console.ReadLine());
            var truck = vehicleFactory.Create(Console.ReadLine());
            var bus = vehicleFactory.Create(Console.ReadLine());

            vehicles.AddRange(new Vehicle[] { car, truck, bus });

            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var input = Console.ReadLine();

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
                    //var busVehicle = vechicle as Bus;
                    //Console.WriteLine(busVehicle.DriveEmpty(amount));
                    Console.WriteLine(((Bus)vehicle).DriveEmpty(amount));
                }
            }

            vehicles.ForEach(v => Console.WriteLine(v));
        }
    }
}
