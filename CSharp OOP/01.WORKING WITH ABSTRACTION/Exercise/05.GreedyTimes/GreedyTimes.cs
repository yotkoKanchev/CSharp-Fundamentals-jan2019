using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class GreedyTimes
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            TresureBag bag = new TresureBag(bagCapacity);

            string[] safeItems = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < safeItems.Length; i += 2)
            {
                string tresureName = safeItems[i];
                long amount = long.Parse(safeItems[i + 1]);

                if (tresureName.Length == 3)
                {
                    var cash = new Cash(tresureName, amount);
                    bag.AddCash(cash);
                }
                else if (tresureName.ToLower().EndsWith("gem"))
                {
                    var gem = new Gem(tresureName, amount);
                    bag.AddGem(gem);
                }
                else if (tresureName.ToLower() == "gold")
                {
                    bag.AddGold(amount);
                }
            }

            Console.WriteLine(bag);
        }
    }
}
