namespace _05._Record_Unique_Names
{
    using System;
    using System.Collections.Generic;

    class RecordUniqueNames
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();
            int namesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < namesCount; i++)
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
