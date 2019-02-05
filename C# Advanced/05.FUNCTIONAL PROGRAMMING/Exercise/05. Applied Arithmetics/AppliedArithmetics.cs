namespace _05._Applied_Arithmetics
{
    using System;
    using System.Linq;

    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int[]> addOne = nums => nums.Select(x => x + 1).ToArray();
            Func<int[], int[]> multiplyByTwo = nums => nums.Select(x => x * 2).ToArray();
            Func<int[], int[]> subtractOne = nums => nums.Select(x => x - 1).ToArray();
            Action<int[]> printArray = nums => Console.WriteLine(string.Join(" ", nums));

            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = addOne(numbers);
                        break;
                    case "multiply":
                        numbers = multiplyByTwo(numbers);
                        break;
                    case "subtract":
                        numbers = subtractOne(numbers);
                        break;
                    case "print":
                        printArray(numbers);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
