namespace P03.Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string driver)
        {
            this.Model = "488-Spider";
            this.Driver = driver;
        }
        public string Model { get; }

        public string Driver { get; }

        public string PushBrakes()
        {
            return "Brakes!";
        }

        public string PushGas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.PushBrakes()}/{this.PushGas()}/{this.Driver}";
        }
    }
}
