namespace P06.BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var mammals = new List<IMammal>();

            while (true)
            {
                var inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var inhabitent = inputArgs[0];

                if (inhabitent?.ToLower() == "end")
                {
                    break;
                }

                var type = inputArgs[0];
                var name = inputArgs[1];

                IMammal mammal = null;

                switch (type)
                {
                    case "Citizen":
                        var age = int.Parse(inputArgs[2]);
                        var id = inputArgs[3];
                        var birthdate = inputArgs[4];
                        mammal = new Citizen(name, age, id, birthdate);
                        break;
                    case "Pet":
                        birthdate = inputArgs[2];
                        mammal = new Pet(name, birthdate);
                        break;
                    default:
                        break;
                }

                if (mammal != null)
                {
                    mammals.Add(mammal);
                }
            }

            var askedYear = Console.ReadLine();

            mammals.Where(m => m.Birthdate.EndsWith(askedYear)).ToList().ForEach(m => Console.WriteLine(m.Birthdate));
        }
    }
}

