namespace _02._Basic_Queue_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            int[] arguments = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] numbersArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> numberQueue = new Queue<int>();

            int numbersToEnqueu = arguments[0];
            int numbersToDenqueu = arguments[1];
            int numbersToLookFor = arguments[2];

            for (int i = 0; i < Math.Min(numbersToEnqueu,numbersArray.Length); i++)
            {
                numberQueue.Enqueue(numbersArray[i]);
            }

            int numbersCount = numberQueue.Count;

            for (int i = 0; i < Math.Min(numbersCount,numbersToDenqueu); i++)
            {
                numberQueue.Dequeue();
            }

            if (numberQueue.Contains(numbersToLookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numberQueue.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(numberQueue.Min());
                }
            }
        }
    }
}
