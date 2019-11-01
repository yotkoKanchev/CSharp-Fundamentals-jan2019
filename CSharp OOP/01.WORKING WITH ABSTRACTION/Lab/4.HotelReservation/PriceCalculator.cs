namespace P4HotelReservation
{
    using System;

    static class PriceCalculator
    {
        public static decimal GetTotalPrice(string input)
        {
            var arguments = input.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            var pricePerDay = decimal.Parse(arguments[0]);
            var days = int.Parse(arguments[1]);
            var season = arguments[2];

            var discount = 1m;

            if (arguments.Length > 3)
            {
                var discountType = arguments[3];
                discount = 1 - (decimal)(DiscountType)Enum.Parse(typeof(DiscountType), discountType) / 100;
            }

            var seasonMultiplyer = (int)(Season)Enum.Parse(typeof(Season), season);
            var totalPrice = pricePerDay * days * seasonMultiplyer * discount;

            return totalPrice;
        }
    }
}
