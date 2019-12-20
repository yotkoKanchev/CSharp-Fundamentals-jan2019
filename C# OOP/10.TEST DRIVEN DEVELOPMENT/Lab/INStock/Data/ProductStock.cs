namespace INStock.Data
{
    using Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductStock : IProductStock
    {
        private List<IProduct> products;

        public ProductStock()
        {
            this.products = new List<IProduct>();
        }

        public void Add(IProduct product)
        {
            this.products.Add(product);
        }

        public bool Remove(IProduct product)
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(IProduct product)
        {
            var hasProduct = this.products.Any(p => p.Label == product.Label);

            return hasProduct;
        }

        public int Count => this.products.Count;

        public IProduct Find(int index)
        {

            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Given index is not valid");
            }

            var product = this.products[index];

            return product;
        }

        public IProduct FindByLabel(string label)
        {
            var product = this.products.FirstOrDefault(p => p.Label == label);

            if (product == null)
            {
                throw new ArgumentException($"Product {label} doesn not exist");
            }

            return product;
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            var productsInRange = this.products
                .Where(p => (double)p.Price >= lo && (double)p.Price <= hi)
                .OrderByDescending(p => p.Price)
                .ToList();

            return productsInRange;
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            var productsWithPrice = this.products.Where(p => (double)p.Price == price).ToList();

            return productsWithPrice;
        }
        public IProduct FindMostExpensiveProduct()
        {
            var mostExpensiveProduct = this.products.OrderByDescending(p => p.Price).First();

            return mostExpensiveProduct;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            var productsWithQunatity = this.products.Where(p => p.Quantity >= quantity).ToList();

            return productsWithQunatity;
        }


        public IEnumerator<IProduct> GetEnumerator()
        {
            for (int i = this.products.Count - 1; i >= 0; i--)
            {
                yield return this.products[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public IProduct this[int index]
        {
            get { return this[index]; }

            set
            {
                this[index] = value;
            }
        }
    }
}
