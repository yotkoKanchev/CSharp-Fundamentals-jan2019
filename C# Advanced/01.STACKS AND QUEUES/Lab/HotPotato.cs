namespace _6._Hot_Potato
{
    using System;
    using System.Collections.Generic;

    class HotPotato
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Queue<string> queueNames = new Queue<string>(names);

            int n = int.Parse(Console.ReadLine());

            while (queueNames.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    queueNames.Enqueue(queueNames.Dequeue());
                }
                Console.WriteLine($"Removed {queueNames.Dequeue()}");
            }
            Console.WriteLine($"Last is {queueNames.Dequeue()}");
        }
    }
}
