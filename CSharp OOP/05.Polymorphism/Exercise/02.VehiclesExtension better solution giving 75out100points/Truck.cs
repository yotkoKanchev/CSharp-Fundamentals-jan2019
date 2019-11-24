namespace P02.Vehicles
{
    public class Truck : Vehicle
    {
        private const double acFuelConsumtionIncrease = 1.6;
        private const double refuelingLossPercentage = 95 / 100;

        public Truck(double fuelQuantity, double fuelConsumtion, double tankCapacity)
            : base(fuelQuantity, fuelConsumtion, tankCapacity)
        {
        }

        public override double AcFuelConsumptionIncrease => acFuelConsumtionIncrease;

        public override double RefuilingLostCoef => refuelingLossPercentage;
    }
}

