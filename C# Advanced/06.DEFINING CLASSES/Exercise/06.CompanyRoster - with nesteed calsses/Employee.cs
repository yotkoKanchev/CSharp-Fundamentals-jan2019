namespace _06.CompanyRoster
{
    public class Employee
    {
        private string name;
        private decimal salary;
        private string position;
        private Department department;
        private string email;
        private int age;


        public Employee(string name, decimal salary, string position, Department department)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
            this.email = "n/a";
            this.age = -1;
        }

        public string Name { get { return this.name; } }
        public decimal Salary { get { return this.salary; } }
        public string Email { get { return this.email; } set{ this.email = value; } }
        public int Age { get { return this.age; } set { this.age = value; } }
    }
}
