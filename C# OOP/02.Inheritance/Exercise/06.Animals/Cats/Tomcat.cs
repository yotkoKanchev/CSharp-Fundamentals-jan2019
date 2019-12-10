namespace Animals.Cats
{
    using System;

    public class Tomcat : Cat
    {
        private const string DefaultGender = "male";

        public Tomcat(string name, int age, string gender) 
            : base(name, age, DefaultGender)
        {
        }

        public Tomcat(string name, int age)
            : base(name, age, DefaultGender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
