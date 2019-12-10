namespace P4HotelReservation
{
    using System;

    public class HotelReservation
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var result = PriceCalculator.GetTotalPrice(input);
            Console.WriteLine($"{result:f2}");
        }
    }
}
