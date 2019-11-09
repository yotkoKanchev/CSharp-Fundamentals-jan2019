﻿namespace P01ClassBoxData
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var length = double.Parse(Console.ReadLine());    
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            try
            {
                var box = new Box(length, width, height);
                Console.WriteLine(box);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
