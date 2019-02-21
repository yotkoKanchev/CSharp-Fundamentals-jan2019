namespace _01.Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Hospital
    {
        public class Department
        {
            private string departmentName;
            private Dictionary<int, List<string>> rooms;
            private int roomsCount;

            public Department(string departmentName)
            {
                this.rooms = new Dictionary<int, List<string>>();
                this.departmentName = departmentName;
            }

            public string DepartmentName { get { return this.departmentName; } set { } }

            public void AddClient(string patient)
            {
                if (this.rooms.Count == 0)
                {
                    this.roomsCount = 1;
                    this.rooms[roomsCount] = new List<string>();
                }

                if (this.rooms[this.roomsCount].Count < 3)
                {
                    this.rooms[this.roomsCount].Add(patient);
                }
                else
                {
                    if (this.roomsCount < 20)
                    {
                        this.roomsCount += 1;
                        this.rooms[this.roomsCount] = new List<string>();
                        this.rooms[this.roomsCount].Add(patient);
                    }

                }
            }
        }

        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            List<Department> hospital = new List<Department>();

            string inputLine = Console.ReadLine();

            while (inputLine != "Output")
            {
                string[] tokens = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 4)
                {
                    string departmentName = tokens[0];
                    string doctorName = tokens[1] + " " + tokens[2];
                    string clientName = tokens[3];

                    if (!hospital.Any(x => x.DepartmentName == departmentName))
                    {
                        Department department = new Department(departmentName);
                        hospital.Add(department);
                    }

                    hospital.Find(x => x.DepartmentName == departmentName).AddClient(clientName);

                    if (!doctors.ContainsKey(doctorName))
                    {
                        doctors[doctorName] = new List<string>();
                    }

                    doctors[doctorName].Add(clientName);
                }

                inputLine = Console.ReadLine();
            }

            inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                string[] tokens = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 1)
                {
                    string deparmentName = tokens[0];

                    Department currentDepartment = hospital.FirstOrDefault(x => x.DepartmentName == deparmentName);

                    foreach (var room in currentDepartment.DepartmentName)
                    {
                        foreach (var client in room.Value)
                        {
                            Console.WriteLine(client);
                        }
                    }
                }
                else
                {
                    string askedDoctor = tokens[0] + " " + tokens[1];

                    if (doctors.ContainsKey(askedDoctor))
                    {
                        List<string> patients = doctors[askedDoctor];

                        foreach (var patient in patients.OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                    else
                    {
                        string deparmentName = tokens[0];

                        Department currentDepartment = hospital.FirstOrDefault(x => x.DepartmentName == deparmentName);
                        int askedRoom = int.Parse(tokens[1]);

                        if (currentDepartment.Rooms.ContainsKey(askedRoom))
                        {
                            foreach (var client in currentDepartment.Rooms[askedRoom].OrderBy(x => x))
                            {
                                Console.WriteLine(client);
                            }
                        }
                    }
                }

                inputLine = Console.ReadLine();
            }
        }
    }
}
