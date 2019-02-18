namespace _06.GenericCountMethodDouble
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main()
        {
            int elementsCount = int.Parse(Console.ReadLine());

            List<double> elements = new List<double>();

            for (int i = 0; i < elementsCount; i++)
            {
                elements.Add(double.Parse(Console.ReadLine()));
            }

            double comperisonElement = double.Parse(Console.ReadLine());

            var box = new Box<double>(elements);

            Console.WriteLine(box.GetCount(comperisonElement));
        }
    }
}
