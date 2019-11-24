namespace P02.Vehicles
{
    public class Car : Vehicle
    {
        private const double acFuelConsumtionIncrease = 0.9;

        public Car(double fuelQuantity, double fuelConsumtion, double tankCapacity)
            : base(fuelQuantity, fuelConsumtion, tankCapacity)
        {
        }

        public override double AcFuelConsumptionIncrease => acFuelConsumtionIncrease;
    }
}
