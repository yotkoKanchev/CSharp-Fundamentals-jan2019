namespace _02._Knights_of_Honor
{
    using System;

    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = name => Console.WriteLine($"Sir {name}");

            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
