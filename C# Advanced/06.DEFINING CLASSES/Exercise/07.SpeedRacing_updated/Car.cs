namespace _07.SpeedRacing
{
    using System;
        
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKm;
        private int totalDistance;

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumptionPerKm = fuelConsumption;
            this.totalDistance = 0;
        }

        public string Model { get { return this.model; } }

        public void Drive(int distance)
        {
            double fuelNeeded = this.fuelConsumptionPerKm * distance;
            if (fuelNeeded <= this.fuelAmount)
            {
                this.fuelAmount -= fuelNeeded;
                this.totalDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive") ;
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.fuelAmount:f2} {this.totalDistance}";
        }
    }
}
