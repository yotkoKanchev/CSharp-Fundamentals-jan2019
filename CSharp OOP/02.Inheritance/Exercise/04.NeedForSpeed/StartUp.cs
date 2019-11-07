namespace NeedForSpeed
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var car = new Car(100, 100);

            car.Drive(100);

            Console.WriteLine(car.Fuel);
        }
    }
}

