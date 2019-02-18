namespace _05.GenericCountMethodString
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int elementsCount = int.Parse(Console.ReadLine());

            List<string> elements = new List<string>();

            for (int i = 0; i < elementsCount; i++)
            {
                elements.Add(Console.ReadLine());
            }

            string comperisonElement = Console.ReadLine();

            var box = new Box<string>(elements);

            Console.WriteLine(box.GetCount(comperisonElement));
        }
    }
}
