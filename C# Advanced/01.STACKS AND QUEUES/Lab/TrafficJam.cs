namespace _7._Traffic_Jam
{
    using System;
    using System.Collections.Generic;

    class TrafficJam
    {
        static void Main(string[] args)
        {
            int passingCarsCount = int.Parse(Console.ReadLine());

            string inputLine = Console.ReadLine();

            Queue<string> carsQueue = new Queue<string>();

            int counter = 0;

            while (inputLine.ToLower() != "end")
            {
                string command = inputLine;

                if (command.ToLower() == "green")
                {
                    if (passingCarsCount > carsQueue.Count)
                    {
                        passingCarsCount = carsQueue.Count;
                    }

                    for (int i = 0; i < passingCarsCount; i++)
                    {
                        Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                        counter++;
                    }
                }
                else
                {
                    string car = command;
                    carsQueue.Enqueue(car);
                }

                inputLine = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");

        }
    }
}
