namespace P04Froggy
{
    using System;
    using System.Linq;

    public class Froggy
    {
        public static void Main()
        {
            var stones = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lake = new Lake(stones);

            Console.WriteLine(string.Join(", ", lake));

        }
    }
}
