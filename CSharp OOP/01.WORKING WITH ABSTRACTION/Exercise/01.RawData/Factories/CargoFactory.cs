namespace P01RawData.Factories
{
    using P01RawData.Models;

    public class CargoFactory
    {
        public Cargo Create(string[] args)
        {
            var weight = int.Parse(args[0]);
            var type = args[1];

            return new Cargo(weight, type);
        }
    }
}
