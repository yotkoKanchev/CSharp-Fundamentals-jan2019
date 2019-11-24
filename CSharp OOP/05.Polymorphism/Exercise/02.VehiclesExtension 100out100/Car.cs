namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double CarFuelLoseCoef = 1;
        private const double ACConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double AdditionalConsumtion { get; protected set; }  = ACConsumption;

        public override double FuelLosesCoef => CarFuelLoseCoef;
    }
}
