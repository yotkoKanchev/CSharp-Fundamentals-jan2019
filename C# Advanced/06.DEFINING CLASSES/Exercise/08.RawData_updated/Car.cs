namespace _08.RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private TiresSet tiresSet;

        public Car(string model, Engine engine, Cargo cargo, TiresSet tiresSet)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tiresSet = tiresSet;
        }

        public Cargo Cargo { get { return this.cargo; } }
        public TiresSet TiresSet { get { return this.tiresSet; } }
        public Engine Engine { get { return this.engine; } }

        public override string ToString()
        {
            return this.model;
        }
    }
}
