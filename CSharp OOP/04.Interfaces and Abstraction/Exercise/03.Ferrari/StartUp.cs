namespace P03.Ferrari
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var name = Console.ReadLine();

            ICar ferarri = new Ferrari(name);
            Console.WriteLine(ferarri);
        }
    }
}
