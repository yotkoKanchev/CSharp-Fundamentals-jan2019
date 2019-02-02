using System;
using System.Linq;

namespace _05.DateModifier
{
    class StartUp
    {
        public static void Main()
        {
            int[] startDate = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] endDate = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            DateTime start = new DateTime(startDate[0], startDate[1], startDate[2]);
            DateTime end = new DateTime(endDate[0], endDate[1], endDate[2]);

            DateModifier dateModifier = new DateModifier(start, end);

            Console.WriteLine(dateModifier.GetDaysDifference());

        }
    }
}
