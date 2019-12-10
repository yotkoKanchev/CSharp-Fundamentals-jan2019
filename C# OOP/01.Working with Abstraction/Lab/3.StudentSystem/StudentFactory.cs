namespace P03StudentSystem
{
    public class StudentFactory
    {
        public Student Create(string[] args)
        {
            var name = args[1];
            var age = int.Parse(args[2]);
            var grade = double.Parse(args[3]);

            return new Student(name, age, grade);
        }
    }
}
