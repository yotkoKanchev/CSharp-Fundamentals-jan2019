namespace P01.Vehicles
{
    using System;

    public class Car : Vehicle
    {
        private const double acFuelConsumtionIncrease = 0.9;

        public Car(double fuelQuantity, double fuelConsumtion)
            : base(fuelQuantity, fuelConsumtion)
        {
            this.FuelConsumption += acFuelConsumtionIncrease;
        }
    }
}
