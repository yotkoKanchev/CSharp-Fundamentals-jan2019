﻿namespace CarManufacturer
{
    using CarManufacturer;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumtion = double.Parse(Console.ReadLine());

            Car car = new Car();
            Car secondCar = new Car(make, model, year);
            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumtion);
        }
    }
}