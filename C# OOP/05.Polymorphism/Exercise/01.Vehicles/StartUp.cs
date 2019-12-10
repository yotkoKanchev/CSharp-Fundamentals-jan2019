namespace P01.Vehicles
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var vehicleFactory = new VehicleFactory();
            var car = vehicleFactory.Create(Console.ReadLine());
            var truck = vehicleFactory.Create(Console.ReadLine());

            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var command = Console.ReadLine();
                ExecuteCommand(command, car, truck);
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void ExecuteCommand(string input, Vehicle car, Vehicle truck)
        {
            var commandArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var command = commandArgs[0];
            var vehicleType = commandArgs[1];
            var value = double.Parse(commandArgs[2]);

            if (vehicleType == "Car")
            {
                if (command == "Drive")
                {
                    Console.WriteLine(car.Drive(value));
                }
                else if (command == "Refuel")
                {
                    car.Refuel(value);
                }
            }
            else if (vehicleType == "Truck")
            {
                if (command == "Drive")
                {
                    Console.WriteLine(truck.Drive(value));
                }
                else if (command == "Refuel")
                {
                    truck.Refuel(value);
                }
            }
        }
    }
}
