namespace P05.BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var inhabitants = new List<IIdentyfiable>();

            while (true)
            {
                var inputArgs = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs[0]?.ToLower() == "end")
                {
                    break;
                }

                IIdentyfiable inhabitant;

                if (inputArgs.Length == 2)
                {
                    inhabitant = new Robot(inputArgs[0], inputArgs[1]);
                }
                else 
                {
                    inhabitant = new Citizen(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]);
                }

                inhabitants.Add(inhabitant);
            }

            var searchedIdEndingPart = Console.ReadLine();
            inhabitants.Where(i => i.Id.EndsWith(searchedIdEndingPart)).ToList().ForEach(i => Console.WriteLine(i.Id));
        }
    }
}
