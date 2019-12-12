namespace P06.ValidPerson
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            try
            {
                var pesho = new Person("Pesho", "Peshev", 24);
                Console.WriteLine($"Created Person -> {pesho.FirstName} {pesho.LastName} on {pesho.Age} years");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }

            try
            {
                var personNoFirstName = new Person(string.Empty, "Peshov", 24);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }

            try
            {
                var personNoLastName = new Person("Pesho", string.Empty, 24);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }

            try
            {
                var personNegativeAge = new Person("Pesho", "Peshev", -1);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }

            try
            {
                var personOver120Age = new Person("Pesho", "Peshev", 121);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }

        }
    }
}
