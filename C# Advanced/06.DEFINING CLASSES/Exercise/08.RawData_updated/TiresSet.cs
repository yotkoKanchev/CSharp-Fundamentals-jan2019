namespace _08.RawData
{
    public class TiresSet
    {
        private Tire[] tiresSet = new Tire[4];

        public TiresSet(string[] tiresData)
        {
            this.tiresSet[0] = new Tire(double.Parse(tiresData[0]), int.Parse(tiresData[1]));
            this.tiresSet[1] = new Tire(double.Parse(tiresData[2]), int.Parse(tiresData[3]));
            this.tiresSet[2] = new Tire(double.Parse(tiresData[4]), int.Parse(tiresData[5]));
            this.tiresSet[3] = new Tire(double.Parse(tiresData[6]), int.Parse(tiresData[7]));
        }

        public Tire[] Tires { get { return this.tiresSet; } }
    }
}
