namespace P02.EnterNumbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public const int start = 1;
        public const int end = 100;
        public static void Main()
        {
            var numbersAsStrings = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var counter = 0;

            while (counter < numbersAsStrings.Length)
            {
                try
                {
                    ReadNumber(numbersAsStrings[counter]);
                    counter++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Enter new Numbers: ");
                    counter = 0;

                    numbersAsStrings = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                }
            }

            Console.WriteLine("All Numbers are valid !!!");
        }

        public static void ReadNumber(string numberAsString)
        {
            if (!numberAsString.All(char.IsDigit))
            {
                throw new FormatException("Invalid input !!!");
            }

            var number = int.Parse(numberAsString);

            if (number < start || number > end)
            {
                throw new ArgumentException($"Number must be between {start} and {end} inclusively !!!");
            }
        }
    }
}
