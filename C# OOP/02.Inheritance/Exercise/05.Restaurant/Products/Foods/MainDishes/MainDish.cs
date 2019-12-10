namespace Restaurant.Products.Foods.MainDishes
{
    public abstract class MainDish : Food
    {
        public MainDish(string name, decimal price, double grams) 
            : base(name, price, grams)
        {
        }
    }
}
