namespace _04._Find_Evens_or_Odds
{
    using System;
    using System.Linq;

    class FindEvenOrOdds
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string evenOrOdd = Console.ReadLine();

            Func<int, bool> checker = choosePredicate(evenOrOdd);

            for (int i = numbers[0]; i <= numbers[1]; i++)
            {
                if (checker(i))
                {
                    Console.Write(i + " ");
                }
            }
        }

        public static Func<int,bool> choosePredicate(string evenOrOdd)
        {
            switch (evenOrOdd)
            {
                case "even": return x => x % 2 == 0;
                case "odd": return x => x % 2 != 0;
                default: return null;
            }
        }        
    }
}
