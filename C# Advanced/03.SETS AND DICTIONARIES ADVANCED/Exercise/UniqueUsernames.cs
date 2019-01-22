namespace _01._Unique_Usernames
{
    using System;
    using System.Collections.Generic;

    class UniqueUsernames
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();
            int usernamesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < usernamesCount; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
