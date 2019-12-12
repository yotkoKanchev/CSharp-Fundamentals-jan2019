namespace P06.ValidPerson
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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
