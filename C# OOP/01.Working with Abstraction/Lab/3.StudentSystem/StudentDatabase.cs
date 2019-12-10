using System.Collections.Generic;

namespace P03StudentSystem
{
    public class StudentDatabase
    {
        private Dictionary<string, Student> students;

        public StudentDatabase()
        {
            this.students = new Dictionary<string, Student>();
        }

        public void Add(Student student)
        {
            if (!this.students.ContainsKey(student.Name))
            {
                this.students.Add(student.Name, student);
            }
        }

        public bool IsStudentExist(string name)
        {
            return this.students.ContainsKey(name);
        }

        public Student Find(string name)
        {
            return this.students[name];
        }

    }
}
