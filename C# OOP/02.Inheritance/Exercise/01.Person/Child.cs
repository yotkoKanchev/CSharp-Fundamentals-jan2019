using System;

namespace P01.Person
{
    public class Child : Person
    {
        private int age;

        public Child(string name, int age)
            : base(name, age)
        {
        }

        //public override int Age
        //{
        //    get
        //    {
        //        return this.age;
        //    }

        //    set
        //    {
        //        if(value > 15)
        //        {
        //            throw new ArgumentException("Age must be less than 15 years");
        //        }

        //        this.age = value;
        //    }
        //}
    }
}

