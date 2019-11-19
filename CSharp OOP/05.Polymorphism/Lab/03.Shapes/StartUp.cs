namespace Shapes
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var shapes = new List<Shape>();

            shapes.Add(new Circle(2));
            shapes.Add(new Rectangle(2, 3));
            shapes.Add(new Rectangle(2.2, 3.6));
            shapes.Add(new Circle(2.7));
            shapes.Add(new Circle(8));
            shapes.Add(new Rectangle(12, 13));

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.CalculateArea());
                Console.WriteLine(shape.CalculatePerimeter());
                Console.WriteLine(shape.Draw());
            }
        }
    }
}
