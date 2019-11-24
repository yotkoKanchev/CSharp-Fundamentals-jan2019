namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double BusFuelLoseCoef = 1;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double AdditionalConsumtion { get; protected set; } = 1.4;

        public override double FuelLosesCoef => BusFuelLoseCoef;

        public void DriveEmpty(double distance)
        {
            this.AdditionalConsumtion = 0;

            System.Console.WriteLine(this.Drive(distance));
        }
    }
}
