namespace P03.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;
        private Validator validator;

        public Person(string name, decimal money)
        {
            this.validator = new Validator();
            this.products = new List<Product>();
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {

            get => this.name;
            private set
            {
                validator.ValidateName(value);
                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            private set
            {
                validator.ValidateAmount(value);
                this.money = value;
            }
        }

        public string BuyProduct(Product product)
        {
            if (product.Cost <= this.Money)
            {
                this.products.Add(product);
                this.Money -= product.Cost;
                return $"{this.Name} bought {product.Name}";
            }
            else
            {
                return $"{this.Name} can't afford {product.Name}";
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (this.products.Count > 0)
            {
                sb.AppendLine($"{this.Name} - {string.Join(", ", this.products)}");
            }
            else
            {
                sb.AppendLine($"{this.Name} - Nothing bought");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
