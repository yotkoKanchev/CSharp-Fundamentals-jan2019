namespace _12._Cups_and_Bottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CupsAndBottles
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray()
                );

            Stack<int> bottles = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray()
                );

            int wastedWater = 0;

            while (cups.Any() && bottles.Any())
            {
                int currentCup = cups.Peek();
                int currentBottle = bottles.Peek();

                if (currentBottle >= currentCup)
                {
                    wastedWater += currentBottle - currentCup;
                    cups.Dequeue();
                    bottles.Pop();
                }
                else
                {
                    while (currentCup>0)
                    {
                        if (currentBottle >= currentCup)
                        {
                            wastedWater += currentBottle - currentCup;
                            cups.Dequeue();
                            bottles.Pop();
                            currentCup -= currentBottle;
                        }
                        else
                        {
                            currentCup -= currentBottle;
                            bottles.Pop();
                            currentBottle = bottles.Peek();
                        }                        
                    }
                }
            }

            if (bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ",cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
