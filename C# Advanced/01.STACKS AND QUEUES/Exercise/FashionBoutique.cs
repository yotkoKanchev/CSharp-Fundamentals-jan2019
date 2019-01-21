namespace _05._Fashion_Boutique
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FashionBoutique
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int racksCapacity = int.Parse(Console.ReadLine());
                        
            Stack<int> clothesStack = new Stack<int>();

            if (racksCapacity > 0)
            {
                int racksCounter = 1;

                foreach (var cloth in clothes)
                {
                    clothesStack.Push(cloth);
                }

                int currentRackCapacity = racksCapacity;

                while (clothesStack.Count > 0)
                {
                    if (clothesStack.Peek() < currentRackCapacity)
                    {
                        currentRackCapacity -= clothesStack.Pop();
                    }
                    else if (clothesStack.Peek() == currentRackCapacity)
                    {
                        clothesStack.Pop();
                        currentRackCapacity = racksCapacity;
                        if (clothesStack.Count > 0)
                        {
                            racksCounter++;
                        }
                    }
                    else if (clothesStack.Peek() > currentRackCapacity)
                    {
                        racksCounter++;
                        currentRackCapacity = racksCapacity;
                    }
                }
                Console.WriteLine(racksCounter);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
