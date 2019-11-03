namespace P01RawData.Factories
{
    using P01RawData.Models;

    public class EngineFactory
    {
        public Engine Create(string[] args)
        {
            var speed = int.Parse(args[0]);
            var power = int.Parse(args[1]);

            return new Engine(speed, power);
        }
    }
}
