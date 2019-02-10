namespace _06.CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CompanyRoster
    {
        public static void Main()
        {
            List<Department> departments = new List<Department>();
            List<Employee> employes = new List<Employee>();

            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                string[] personData = Console.ReadLine().Split();
                string name = personData[0];
                decimal salary = decimal.Parse(personData[1]);
                string position = personData[2];
                string departmentName = personData[3];
                                
                Department department = new Department(departmentName);

                Employee employee = new Employee(name, salary, position, department);

                if (personData.Length == 6)
                {
                    string email = personData[4];
                    int age = int.Parse(personData[5]);
                    employee.Email = email;
                    employee.Age = age;
                }
                else if (personData.Length == 5)
                {
                    if (personData[4].Contains("@"))
                    {
                        string email = personData[4];
                        employee.Email = email;
                    }
                    else
                    {
                        int age = int.Parse(personData[4]);
                        employee.Age = age;
                    }
                }


                if (!departments.Any(x => x.Name == departmentName))
                {
                    department.AddEmployee(employee);
                    departments.Add(department);
                }
                else
                {
                    departments.Find(x => x.Name == departmentName).AddEmployee(employee);
                }     
            }

            var bestDepartment = departments.OrderByDescending(x => x.Employes.Select(y => y.Salary).Average()).FirstOrDefault();

            Console.WriteLine(bestDepartment);
        }
    }
}
