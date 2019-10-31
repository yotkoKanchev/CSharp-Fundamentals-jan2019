namespace P1RhombusOfStars
{
    using System;

    public class RhombusOfStars
    {
        public static void Main()
        {
            var starsCount = int.Parse(Console.ReadLine());
            var rombusDrawer = new RhombusDrawer();
            Console.WriteLine(rombusDrawer.Draw(starsCount));
        }
    }
}
