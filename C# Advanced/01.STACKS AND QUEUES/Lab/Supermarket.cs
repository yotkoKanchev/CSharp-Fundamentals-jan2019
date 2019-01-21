namespace _5._Supermarket_1
{
    using System;
    using System.Collections.Generic;

    class Supermarket
    {
        static void Main(string[] args)
        {
            Queue<string> supermarket = new Queue<string>();
            string inputLine = Console.ReadLine();

            while (inputLine.ToLower() != "end")
            {
                if (inputLine.ToLower() == "paid")
                {
                    int numberOfNames = supermarket.Count;
                    for (int i = 0; i < numberOfNames; i++)
                    {
                        Console.WriteLine(supermarket.Dequeue());

                    }
                }
                else
                {
                    supermarket.Enqueue(inputLine);
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine($"{supermarket.Count} people remaining.");
        }
    }
}
