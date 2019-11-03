using System.Collections.Generic;

namespace P04_Hospital
{
    public class Room
    {
        public Room(int number)
        {
            this.Number = number;
            this.Patients = new List<Patient>();    
        }
        public List<Patient> Patients { get; private set; }

        public int Number { get; private set; }

        public void Add(Patient patient)
        {
            this.Patients.Add(patient);
        }
        internal bool HasEmptyBed()
        {
            return this.Patients.Count < 3;
        }
    }
}
