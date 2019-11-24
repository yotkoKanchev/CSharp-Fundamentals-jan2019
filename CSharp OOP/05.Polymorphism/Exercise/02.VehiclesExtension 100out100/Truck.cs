namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double TruckFuelLoseCoef = 0.95;
        private const double ACConsumption = 1.6;


        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double AdditionalConsumtion { get; protected set; } = ACConsumption;

        public override double FuelLosesCoef => TruckFuelLoseCoef;
    }
}
