namespace P02.Vehicles
{
    using System;

    public abstract class Vehicle
    {
        private const double refuelingLossCoef = 1;

        private double fuelQuantity;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumtion, double tankCapacity)
        {
            this.tankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumtion;
        }

        public abstract double AcFuelConsumptionIncrease { get; }

        public virtual double RefuilingLostCoef => refuelingLossCoef; 

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            private set
            {
                if (value > this.tankCapacity || value < 0)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; protected set; }

        public virtual void Refuel(double litters)
        {
            if (litters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (litters + this.FuelQuantity > this.tankCapacity)
            {
                throw new ArgumentException($"Cannot fit {litters} fuel in the tank");
            }

            this.FuelQuantity += litters * this.RefuilingLostCoef;
        }

        public string Drive(double distance)
        {
            var neededFuel = distance * (this.FuelConsumption + this.AcFuelConsumptionIncrease);

            if (neededFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
