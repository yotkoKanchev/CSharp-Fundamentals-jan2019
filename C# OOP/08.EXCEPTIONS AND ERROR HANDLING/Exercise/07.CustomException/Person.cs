namespace P07.CustomException
{
    using System;
    using System.Linq;

    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get => this.firstName;

            set
            {               
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "The First Name can not be null or empty.");
                }

                if (value.Any(char.IsNumber) || value.Any(char.IsPunctuation))
                {
                    throw new InvalidPersonNameException("Name should contain only letters !!!");
                }

                firstName = value;
            }
        }
        public string LastName
        {
            get => this.lastName;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "The Last Name can not be null or empty.");
                }

                if (value.Any(char.IsNumber) || value.Any(char.IsPunctuation))
                {
                    throw new InvalidPersonNameException("Name should contain only letters !!!");
                }

                lastName = value;
            }
        }
        public int Age
        {
            get => this.age;

            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("value", "Age should be in range [0, 120].");
                }

                age = value;
            }
        }
    }
}
