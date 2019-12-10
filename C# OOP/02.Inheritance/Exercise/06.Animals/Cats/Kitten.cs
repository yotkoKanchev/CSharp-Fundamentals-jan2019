namespace Animals.Cats
{
    using System;

    public class Kitten : Cat
    {
        private const string DefaultGender = "female";
        public Kitten(string name, int age, string gender) 
            : base(name, age, DefaultGender)
        {
        }

        public Kitten(string name, int age)
            : base(name, age, DefaultGender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
