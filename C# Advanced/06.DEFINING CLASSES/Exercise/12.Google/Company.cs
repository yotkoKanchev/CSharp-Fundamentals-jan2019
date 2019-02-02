﻿using System.Text;

namespace _12.Google
{
    public class Company
    {
        public Company(string name, string department, decimal salary)
        {
            this.Name = name;
            this.Department = department;
            this.Salary = salary;
        }

        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Company:");
            if (this.Name != string.Empty)
            {
                stringBuilder.AppendLine();
                stringBuilder.Append($"{this.Name} {this.Department} {this.Salary:f2}");
            }

            return stringBuilder.ToString();
        }
    }
}
