namespace P02.Vehicles
{
    using System;

    public class VehicleFactory
    {
        public Vehicle Create(string input)
        {
            var vehicleArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var vehicleType = vehicleArgs[0];
            var fuelQuantity = double.Parse(vehicleArgs[1]);
            var fuelConsumption = double.Parse(vehicleArgs[2]);
            var tankCapacity = double.Parse(vehicleArgs[3]);

            Vehicle vehicle;

            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if(vehicleType == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else
            {
                return null;
            }

            return vehicle;
        }
    }
}
