namespace Cars
{
    using System;
    public class Seat : Car
    {
        public Seat(string model, string color)
            : base(model, color)
        {
        }

        public override string ToString()
        {
            return $"{this.Color} {nameof(Seat)} {this.Model}" +
                $"{Environment.NewLine}{ this.Start()}" +
                $"{Environment.NewLine}{this.Stop()}";
        }
    }
}
