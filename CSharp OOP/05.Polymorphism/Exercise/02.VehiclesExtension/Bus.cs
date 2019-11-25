namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double BusACConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double AdditionalConsumtion { get; protected set; } = BusACConsumption;

        public string DriveEmpty(double distance)
        {
            this.AdditionalConsumtion = 0;

            return this.Drive(distance);
        }
    }
}
