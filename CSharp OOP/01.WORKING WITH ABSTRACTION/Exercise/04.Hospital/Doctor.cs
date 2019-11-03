using System.Collections.Generic;

namespace P04_Hospital
{
    public class Doctor
    {
        public Doctor(string name)
        {
            this.Name = name;
            this.Patients = new List<Patient>();
        }

        public string Name { get; private set; }

        public List<Patient> Patients { get; private set; }

        public void AddPatient(Patient patient)
        {
            this.Patients.Add(patient);
        }
    }
}
