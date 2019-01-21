namespace _03._Maximum_and_Minimum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MaxAndMinElement
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int firstNum = tokens[0];

                switch (firstNum)
                {
                    case 1:
                        int numberToPush = tokens[1];
                        numbers.Push(numberToPush);
                        break;
                    case 2:
                        if (numbers.Count > 0)
                        {
                            numbers.Pop();
                        }
                        break;
                    case 3:
                        if (numbers.Count > 0)
                        {
                            Console.WriteLine(numbers.Max());
                        }
                        break;
                    case 4:
                        if (numbers.Count > 0)
                        {
                            Console.WriteLine(numbers.Min());
                        }
                        break;
                    default:
                        break;
                }
            }
            while (numbers.Count > 1)
            {
                Console.Write(numbers.Pop() + ", ");
            }
            if (numbers.Count > 0)
            {
                Console.Write(numbers.Pop());
                Console.WriteLine();
            }
        }
    }
}
