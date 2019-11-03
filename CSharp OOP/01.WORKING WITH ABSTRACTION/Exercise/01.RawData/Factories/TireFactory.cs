using P01RawData.Models;

namespace P01RawData.Factories
{
    public class TireFactory
    {
        public Tire Create(string[] args)
        {
            var pressure = double.Parse(args[0]);
            var age = int.Parse(args[1]);

            return new Tire(pressure, age);
        }
    }
}
