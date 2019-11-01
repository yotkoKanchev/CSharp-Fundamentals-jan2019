namespace P03StudentSystem
{
    class StartUp
    {
        static void Main()
        {
            var students = new StudentDatabase();
            var studentFactory = new StudentFactory();
            StudentSystem studentSystem = new StudentSystem(students, studentFactory);
            studentSystem.Execute();
        }
    }
}
