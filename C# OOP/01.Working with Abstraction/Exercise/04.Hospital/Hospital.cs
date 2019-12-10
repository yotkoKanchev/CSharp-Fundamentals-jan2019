using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Hospital
    {
        public static void Main()
        {
            var departments = new List<Department>();
            var doctors = new List<Doctor>();

            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] arguments = command.Split();
                var departmentName = arguments[0];
                var doctorFirstName = arguments[1];
                var doctorLastName = arguments[2];
                var patientName = arguments[3];
                var doctorFullName = doctorFirstName + " " + doctorLastName;

                var patient = new Patient(patientName);

                if (!doctors.Any(d => d.Name == doctorFullName))
                {
                    var doctor = new Doctor(doctorFullName);
                    doctors.Add(doctor);
                }

                var currentDoctor = doctors.FirstOrDefault(d => d.Name == doctorFullName);
                currentDoctor.AddPatient(patient);


                if (!departments.Any(d => d.Name == departmentName))
                {
                    var department = new Department(departmentName);
                    departments.Add(department);
                }

                var currentDepartment = departments.FirstOrDefault(d => d.Name == departmentName);

                if (currentDepartment.hasAvailableRoom())
                {
                    currentDepartment.AddPatient(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();
                var sb = new StringBuilder();
                if (args.Length == 1)
                {
                    var department = departments.Single(d => d.Name == command);
                    department.Rooms.ForEach(r => r.Patients.ForEach(p => sb.AppendLine(p.Name)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    var deparmentName = args[0];
                    var roomNumber = int.Parse(args[1]);
                    departments
                        .Single(d => d.Name == deparmentName)
                            .Rooms
                            .Single(r => r.Number == roomNumber)
                                .Patients
                                .OrderBy(p => p.Name)
                                .ToList()
                                .ForEach(p => sb.AppendLine(p.Name));
                }
                else
                {
                    var doctorName = $"{args[0]} {args[1]}";
                    doctors
                        .Single(d => d.Name == doctorName)
                            .Patients
                            .OrderBy(p => p.Name)
                            .ToList()
                            .ForEach(p => sb.AppendLine(p.Name));
                }

                Console.WriteLine(sb.ToString().TrimEnd());

                command = Console.ReadLine();
            }
        }
    }
}
