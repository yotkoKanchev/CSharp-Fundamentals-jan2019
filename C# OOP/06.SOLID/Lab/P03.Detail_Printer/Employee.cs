﻿namespace P03.DetailPrinter
{
    public class Employee
    {
        private string name;
        public Employee(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
