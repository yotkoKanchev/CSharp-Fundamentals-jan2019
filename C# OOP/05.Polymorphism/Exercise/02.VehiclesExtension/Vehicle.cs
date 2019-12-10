namespace VehiclesExtension
{
    using System;

    public abstract class Vehicle
    {
        private static double InitialFuelLossCoef = 1;
        private double fuelQuantity;
        private double tankCapacity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.tankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }

        public abstract double AdditionalConsumtion { get; protected set; }

        public virtual double FuelLosesCoef { get; } = InitialFuelLossCoef;

        protected double FuelQuantity
        {
            get => this.fuelQuantity;

            set
            {
                if (value > this.tankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public string Drive(double distance)
        {
            double fuelNeeded = distance * this.fuelConsumption + distance * this.AdditionalConsumtion;

            if (this.FuelQuantity >= fuelNeeded)
            {
                this.FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public void Refuel(double litters)
        {
            if (litters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + litters > this.tankCapacity)
            {
                throw new ArgumentException($"Cannot fit {litters} fuel in the tank");
            }

            this.FuelQuantity += litters - (litters * (1 - FuelLosesCoef));
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
