namespace Socks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Socks
    {
        public static void Main()
        {
            Stack<int> leftSocks = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> rightSocks = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            List<int> result = new List<int>();

            int endOfLoop = Math.Min(leftSocks.Count, rightSocks.Count);

            while (leftSocks.Any() && rightSocks.Any())
            {
                int currentLeftSock = leftSocks.Peek();
                int currentRightSock = rightSocks.Peek();

                if (currentLeftSock == currentRightSock)
                {
                    rightSocks.Dequeue();
                    currentLeftSock += 1;
                    leftSocks.Pop();
                    leftSocks.Push(currentLeftSock);
                }
                else if (currentRightSock > currentLeftSock)
                {
                    leftSocks.Pop();
                }
                else
                {
                    result.Add(currentLeftSock + currentRightSock);
                    leftSocks.Pop();
                    rightSocks.Dequeue();
                }
            }

            Console.WriteLine(result.Max());
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
