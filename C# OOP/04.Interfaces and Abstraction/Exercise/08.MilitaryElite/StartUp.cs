namespace P08.MilitaryElite
{
    using P08.MilitaryElite.Core;
    using P08.MilitaryElite.Models;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var soldierFactory = new SoldierFactory();
            var privates = new List<Private>();

            var soldiers = new List<Soldier>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input?.ToLower() == "end")
                {
                    break;
                }

                try
                {
                    var soldier = soldierFactory.Create(input, privates);
                    if (soldier != null)
                    {
                        soldiers.Add(soldier);
                    }
                }
                catch (Exception ex)
                {
                }
            }

            soldiers.ForEach(s => Console.WriteLine(s));
        }
    }
}
