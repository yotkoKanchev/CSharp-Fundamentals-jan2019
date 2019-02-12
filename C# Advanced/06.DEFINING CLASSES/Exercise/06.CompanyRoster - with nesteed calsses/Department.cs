namespace _06.CompanyRoster
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Department
    {
        private string name;
        private List<Employee> employes;

        public Department(string name)
        {
            this.Name = name;
            this.employes = new List<Employee>();
        }

        public string Name { get { return this.name; } set { this.name = value;} }
        public List<Employee> Employes { get { return this.employes; } }

        public void AddEmployee(Employee employee)
        {
            this.employes.Add(employee);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Highest Average Salary: {this.Name}");

            foreach (var employee in this.employes.OrderByDescending(x=>x.Salary))
            {
                sb.AppendLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }

            return sb.ToString();
        }
    }
}
