namespace P07.CustomException
{
    public class Student : Person
    {
        public Student(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        {
        }

        public string Email { get; set; }
    }
}
