namespace _10._Crossroads
{
    using System;
    using System.Collections.Generic;

    class Crossroads
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> carsQueue = new Queue<string>();
            string inputLine = Console.ReadLine();

            int passedCars = 0;            

            while (inputLine?.ToLower() != "end")
            {            
                if (inputLine == "green")
                {
                    int greenLightLeft = greenLightDuration;
                    int freeWindowLeft = freeWindowDuration;

                    while (greenLightLeft > 0 && carsQueue.Count > 0)
                    {
                        string firstCarOnQueue = carsQueue.Peek();
                        if (firstCarOnQueue.Length <= greenLightLeft)
                        {
                            passedCars++;
                            greenLightLeft -= firstCarOnQueue.Length;
                            carsQueue.Dequeue();
                        }
                        else
                        {
                            if (firstCarOnQueue.Length <= greenLightLeft + freeWindowLeft)
                            {
                                passedCars++;
                                greenLightLeft = 0;
                                freeWindowLeft = freeWindowLeft - (firstCarOnQueue.Length - greenLightLeft);
                            }
                            else
                            {
                                int hitIndex = firstCarOnQueue.Length - freeWindowLeft - greenLightLeft - 1;
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{firstCarOnQueue} was hit at {firstCarOnQueue[firstCarOnQueue.Length-hitIndex - 1]}.");
                                return;
                            }
                        }
                    }
                    
                }
                else
                {
                    string car = inputLine;
                    carsQueue.Enqueue(car);
                }

                inputLine = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
