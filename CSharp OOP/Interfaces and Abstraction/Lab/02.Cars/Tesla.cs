namespace Cars
{
    using System;
    public class Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color, int battery)
            : base(model, color)
        {
            this.Battery = battery;
        }

        public int Battery { get; private set; }

        public override string ToString()
        {
            return $"{this.Color} {nameof(Tesla)} {this.Model} with {this.Battery} Batteries" +
                $"{Environment.NewLine}{this.Start()}" +
                $"{Environment.NewLine}{this.Stop()}";
        }
    }
}
