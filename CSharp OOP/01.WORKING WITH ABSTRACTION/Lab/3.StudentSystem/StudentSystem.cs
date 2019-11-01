namespace P03StudentSystem
{
    using System;
    public class StudentSystem
    {
        private StudentDatabase students;
        private StudentFactory studentFactory;
        public StudentSystem(StudentDatabase students, StudentFactory studentFactory)
        {
            this.students = students;
            this.studentFactory = studentFactory;
        }

        internal void Execute()
        {
            var input = Console.ReadLine();

            while (input?.ToLower() != "exit")
            {
                var commandArguments = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var command = commandArguments[0];

                if (command?.ToLower() == "create")
                {
                    var student = studentFactory.Create(commandArguments);
                    students.Add(student);
                }
                else if (command?.ToLower() == "show")
                {
                    var name = commandArguments[1];
                    if (students.IsStudentExist(name))
                    {
                        Console.WriteLine(students.Find(name));
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
