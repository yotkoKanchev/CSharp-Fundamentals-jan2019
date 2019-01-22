namespace _07._SoftUni_Party
{
    using System;
    using System.Collections.Generic;

    class SoftUniParty
    {
        static void Main(string[] args)
        {
            HashSet<string> vipList = new HashSet<string>();
            HashSet<string> regularList = new HashSet<string>();

            string inputLine = Console.ReadLine();

            while (inputLine?.ToLower() != "party")
            {
                string resevationNumber = inputLine;

                if (char.IsDigit(resevationNumber[0]))
                {
                    vipList.Add(resevationNumber);
                }
                else
                {
                    regularList.Add(resevationNumber);
                }

                inputLine = Console.ReadLine();
            }

            inputLine = Console.ReadLine();

            while (inputLine?.ToLower() != "end")
            {
                string guestToChek = inputLine;
                if (char.IsDigit(guestToChek[0]))
                {
                    vipList.Remove(guestToChek);
                }
                else
                {
                    regularList.Remove(guestToChek);
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine(vipList.Count + regularList.Count);

            foreach (var guest in vipList)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regularList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
