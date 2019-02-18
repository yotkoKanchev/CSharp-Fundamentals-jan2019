namespace _08.Threeuple
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string[] personInput = Console.ReadLine().Split(" ");

            string name = personInput[0] + " " + personInput[1];
            string address = personInput[2];
            string town = personInput[3];

            var personThreeuple = new Threeuple<string,string,string>(name, address, town);

            string[] beerInput = Console.ReadLine().Split(" ");

            string personName = beerInput[0];
            int litters = int.Parse(beerInput[1]);
            bool isDrunk = false;

            if (beerInput[2] == "drunk")
            {
                isDrunk = true;
            }

            var beerThreeuple = new Threeuple<string, int, bool>(personName, litters, isDrunk);

            string[] accountInput = Console.ReadLine().Split(" ");

            string clientName = accountInput[0];
            double balance = double.Parse(accountInput[1]);
            string bank = accountInput[2];

            var accountThreeuple = new Threeuple<string, double, string>(clientName, balance, bank);

            Console.WriteLine(personThreeuple);
            Console.WriteLine(beerThreeuple);
            Console.WriteLine(accountThreeuple);
        }
    }
}
