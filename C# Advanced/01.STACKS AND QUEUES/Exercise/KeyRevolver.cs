namespace _11._Key_Revolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class KeyRevolver
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray()
                );

            Queue<int> locks = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray()
                );
            
            int inteligenceValue = int.Parse(Console.ReadLine());

            int bulletsCount = 0;

            while (locks.Count > 0 && bullets.Count > 0)
            {             
                int currentBullet = bullets.Peek();
                int currnetLock = locks.Peek();
                              

                if (currentBullet <= currnetLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                    bullets.Pop();
                    bulletsCount++;
                    if (bullets.Count == 0)
                    {
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                    bulletsCount++;                    
                }

                if (bulletsCount > 0 && bulletsCount % gunBarelSize == 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${inteligenceValue - (bulletsCount * bulletPrice)}");
            }
        }
    }
}
