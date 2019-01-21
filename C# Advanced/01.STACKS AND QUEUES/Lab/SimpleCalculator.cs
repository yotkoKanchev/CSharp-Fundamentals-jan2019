namespace _3._Simple_Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine()
                .Split()
                .Reverse()
                .ToArray();

            Stack<string> expressions = new Stack<string>();

            foreach (var word in inputLine)
            {
                expressions.Push(word);
            }

            while (expressions.Count > 1)
            {
                int firstNum = int.Parse(expressions.Pop());
                string action = expressions.Pop();
                int secodNum = int.Parse(expressions.Pop());

                if (action == "+")
                {
                    expressions.Push((firstNum + secodNum).ToString());
                }
                else if (action == "-")
                {
                    expressions.Push((firstNum - secodNum).ToString());
                }
            }

            Console.WriteLine(expressions.Pop());
        }
    }
}
