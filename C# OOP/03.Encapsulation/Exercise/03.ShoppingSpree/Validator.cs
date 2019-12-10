namespace P03.ShoppingSpree
{
    using System;

    internal class Validator
    {
        internal void ValidateAmount(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
        }

        internal void ValidateName(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }
    }
}
