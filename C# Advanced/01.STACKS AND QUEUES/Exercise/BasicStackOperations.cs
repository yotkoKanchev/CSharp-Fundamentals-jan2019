namespace _01._Basic_Stack_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();

            int[] arguments = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] numbersArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int numbersToPush = arguments[0];
            int numbersToPop = arguments[1];
            int numberToLookFor = arguments[2];

            for (int i = 0; i < Math.Min(numbersToPush,numbersArray.Length); i++)
            {
                numbers.Push(numbersArray[i]);
            }

            int numbersCount = numbers.Count;

            for (int i = 0; i < Math.Min(numbersToPop, numbersCount); i++)
            {
                numbers.Pop();
            }

            if (numbers.Contains(numberToLookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numbers.Count == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
                Console.WriteLine(numbers.Min());
            }
        }
    }
}
