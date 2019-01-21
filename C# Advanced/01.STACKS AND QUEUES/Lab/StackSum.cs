namespace _2._Stack_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StackSum
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var numbersStack = new Stack<int>();

            foreach (var number in numbers)
            {
                numbersStack.Push(number);
            }

            string inputLine = Console.ReadLine();

            while (inputLine.ToLower() != "end")
            {
                string[] arguments = inputLine.Split();
                string command = arguments[0];

                if (command.ToLower() == "add" )
                {
                    int firstNum = int.Parse(arguments[1]);
                    numbersStack.Push(firstNum);
                    int secondNum = int.Parse(arguments[2]);
                    numbersStack.Push(secondNum);
                }
                else if (command.ToLower() == "remove")
                {
                    int countOfNumbersToRemove = int.Parse(arguments[1]);
                    if (countOfNumbersToRemove <= numbersStack.Count)
                    {
                        for (int i = 0; i < countOfNumbersToRemove; i++)
                        {
                            numbersStack.Pop();
                        }
                    }
                }

                inputLine = Console.ReadLine();
            }
            Console.WriteLine($"Sum: {numbersStack.Sum()}");
        }
    }
}
