namespace P01RawData.Factories
{
    using P01RawData.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CarFactory
    {
        private EngineFactory engineFactory;
        private CargoFactory cargoFactory;
        private TireFactory tireFactory;
        public CarFactory()
        {
            this.engineFactory = new EngineFactory();
            this.cargoFactory = new CargoFactory();
            this.tireFactory = new TireFactory();
        }
        public Car Create(string[] args)
        {
            var carModel = args[0];
            var engineArgs = args.Skip(1).Take(2).ToArray();
            var cargoArgs = args.Skip(3).Take(2).ToArray();
            var tiresArgs = args.Skip(5).ToArray();

            var engine = engineFactory.Create(engineArgs);
            var cargo = cargoFactory.Create(cargoArgs);

            var tiresSet = new List<Tire>();

            for (int i = 0; i < 8; i += 2)
            {
                var tire = tireFactory.Create(tiresArgs.Skip(i).Take(2).ToArray());
                tiresSet.Add(tire);
            }

            return new Car(carModel, engine, cargo, tiresSet);
        }
    }
}
