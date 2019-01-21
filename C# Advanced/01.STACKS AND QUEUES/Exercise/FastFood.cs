namespace _04._Fast_Food
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FastFood
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            Queue<int> ordersQueue = new Queue<int>(orders);
            Console.WriteLine(ordersQueue.Max());

            bool areEnough = true;
            
            while (ordersQueue.Count > 0)
            {
                if (ordersQueue.Peek() <= foodQuantity)
                {
                    foodQuantity -= ordersQueue.Dequeue();
                }
                else
                {
                    areEnough = false;
                    break;
                }
            }

            if (areEnough)
            {
                Console.WriteLine($"Orders complete");
            }
            else
            {
                Console.Write($"Orders left: ");
                int counter = ordersQueue.Count;

                for (int i = 0; i < counter; i++)
                {
                    Console.Write(ordersQueue.Dequeue() + " ");
                }
            }
        }
    }
}
