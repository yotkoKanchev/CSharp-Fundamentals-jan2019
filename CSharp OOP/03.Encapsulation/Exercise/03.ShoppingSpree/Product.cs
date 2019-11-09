using System;

namespace P03.ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;
        private Validator validator;

        public Product(string name, decimal cost)
        {
            this.validator = new Validator();
            this.Name = name;
            this.Cost = cost;
        }

        internal decimal Cost
        {
            get => this.cost;
            private set
            {
                validator.ValidateAmount(value);

                this.cost = value;
            }
        }

        internal string Name
        {
            get => this.name;
            private set
            {
                validator.ValidateName(value);
                this.name = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
