namespace P02.Vehicles
{
    public class Bus : Vehicle
    {
        private const double acFuelConsumtionIncrease = 1.4;

        public Bus(double fuelQuantity, double fuelConsumtion, double tankCapacity)
            : base(fuelQuantity, fuelConsumtion, tankCapacity)
        {
        }

        public override double AcFuelConsumptionIncrease => acFuelConsumtionIncrease;

        public string DriveEmpty(double distance)
        {
            this.FuelConsumption -= acFuelConsumtionIncrease;
            var result = this.Drive(distance);
            this.FuelConsumption += acFuelConsumtionIncrease;
            return result;
        }
    }
}
