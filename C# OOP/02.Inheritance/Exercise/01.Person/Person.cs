using System;

namespace P01.Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.Age = age;
        }

        public virtual int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Age must be more than 0");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {this.name}, Age: {this.Age}";
        }
    }
}
