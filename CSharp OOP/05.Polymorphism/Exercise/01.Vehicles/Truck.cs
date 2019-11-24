namespace P01.Vehicles
{
    using System;

    public class Truck : Vehicle
    {
        private const double acFuelConsumtionIncrease = 1.6;
        private const double refuelingLossPercentage = 95;

        public Truck(double fuelQuantity, double fuelConsumtion)
            : base(fuelQuantity, fuelConsumtion)
        {
            this.FuelConsumption += acFuelConsumtionIncrease;
        }

        public override void Refuel(double litters)
        {
            this.FuelQuantity += litters * (refuelingLossPercentage / 100);
        }
    }
}
