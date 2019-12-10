namespace P01RawData.Models
{
    public class Tire
    {
        private double age;

        public Tire(double pressure, double age)
        {
            this.Pressure = pressure;
            this.age = age;
        }

        public double Pressure { get; private set; }
    }
}