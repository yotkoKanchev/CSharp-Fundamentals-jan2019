using System;

namespace PersonsInfo
{
    public class Person
    {
        private const int MinNameLength = 3;
        private const decimal MinSalary = 460;

        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get => this.firstName;

            private set
            {
                ValidateName(value, "First");

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;

            private set
            {
                ValidateName(value, "Last");

                this.lastName = value;
            }
        }

        public int Age
        {
            get => this.age;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                this.age = value;
            }
        }

        public decimal Salary
        {
            get => this.salary;

            private set
            {
                if (value < MinSalary)
                {
                    throw new ArgumentException($"Salary cannot be less than {MinSalary} leva!");
                }

                this.salary = value;
            }
        }

        private void ValidateName(string value, string type)
        {
            if (value.Length < MinNameLength)
            {
                throw new ArgumentException($"{type} name cannot contain fewer than {MinNameLength} symbols!");
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                percentage /= 2;
            }

            this.Salary *= (1 + percentage / 100);
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}
