namespace _06._Reverse_And_Exclude
{
    using System;
    using System.Linq;

    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int divisionNumber = int.Parse(Console.ReadLine());

            Func<int[], int[]> reverseNumbers = nums => nums.Reverse().ToArray();

            Func<int[], int[]> filterDivisibleNumbers = nums => nums.Where(x => x % divisionNumber != 0).ToArray();

            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));

            print(filterDivisibleNumbers(reverseNumbers(numbers)));

        }
    }
}
