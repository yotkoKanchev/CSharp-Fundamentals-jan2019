namespace P01.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class VehicleFactory
    {
        public Vehicle Create(string input)
        {
            var vehicleArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var vehicleType = vehicleArgs[0];
            var fuelQuantity = double.Parse(vehicleArgs[1]);
            var fuelConsumption = double.Parse(vehicleArgs[2]);

            Vehicle vehicle;

            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }

            return vehicle;
        }
    }
}
