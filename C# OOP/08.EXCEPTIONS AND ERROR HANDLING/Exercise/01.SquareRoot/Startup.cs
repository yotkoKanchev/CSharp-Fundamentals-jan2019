namespace P01.SquareRoot
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            try
            {
                var input = Console.ReadLine();
                var number = int.Parse(input);

                if (number < 0)
                {
                    throw new IndexOutOfRangeException("Number can not be negative !!!");
                }

                if (!input.All(char.IsDigit))
                {
                    throw new FormatException("Invalid input !");
                }

                Console.WriteLine(Math.Sqrt(number));
            }
            catch(SystemException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
