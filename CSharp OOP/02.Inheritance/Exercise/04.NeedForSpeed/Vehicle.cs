namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        private const double DefaulFuelConsumption = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        
        public virtual double FuelConsumption => DefaulFuelConsumption;

        public double Fuel { get; private set; }

        public int HorsePower { get; private set; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption; //(/ 100) author of the problem need to think about that 
        }
    }
}
