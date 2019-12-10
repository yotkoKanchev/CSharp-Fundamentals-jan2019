namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double TruckFuelLoseCoef = 0.95;
        private const double TruckACConsumption = 1.6;


        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double AdditionalConsumtion { get; protected set; } = TruckACConsumption;

        public override double FuelLosesCoef => TruckFuelLoseCoef;
    }
}
