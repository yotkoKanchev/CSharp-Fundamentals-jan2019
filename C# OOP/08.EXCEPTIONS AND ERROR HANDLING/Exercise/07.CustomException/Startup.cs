namespace P07.CustomException
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            try
            {
                var student = new Person("Gin4o", "Peshev", 24);
                Console.WriteLine($"Created Person -> {student.FirstName} {student.LastName} on {student.Age} years");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            catch (InvalidPersonNameException pe)
            {
                Console.WriteLine($"Exception thrown: {pe.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
        }
    }
}
