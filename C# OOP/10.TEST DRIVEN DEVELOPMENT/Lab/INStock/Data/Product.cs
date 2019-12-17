namespace INStock.Data
{
    using Contracts;

    public class Product : IProduct
    {

        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label { get; }

        public decimal Price { get; }

        public int Quantity { get; }

        public int CompareTo(IProduct other)
        {
            var result = 0;

            if (this.Price > other.Price)
            {
                result = 1;
            }
            else if (this.Price < other.Price)
            {
                result = -1;
            }

            return result;
        }
    }
}
