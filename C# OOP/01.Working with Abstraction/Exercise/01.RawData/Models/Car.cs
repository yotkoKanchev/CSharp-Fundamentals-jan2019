namespace P01RawData.Models
{
    using System.Collections.Generic;

    public class Car
    {
        private string model;

        public Car(string model, Engine engine, Cargo cargo, ICollection<Tire> tires)
        {
            this.model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public Engine Engine { get; private set; }

        public Cargo Cargo { get; private set; }

        public ICollection<Tire> Tires { get; private set; }

        public override string ToString()
        {
            return this.model;
        }
    }
}
