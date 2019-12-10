namespace Restaurant.Products.Beverages.HotBeverages
{
    public class Coffee : HotBeverage
    {
        private const double DefaultCoffeeMilliliters = 50;
        private const decimal DefaultCoffeePrice = 3.50M;
        public Coffee(string name, double caffeine) // the author need to specify this in the problem resource !!!
            : base(name, DefaultCoffeePrice, DefaultCoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; internal set; }
    }
}
