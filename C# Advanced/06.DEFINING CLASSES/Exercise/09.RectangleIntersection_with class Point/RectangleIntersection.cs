namespace _09.RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RectangleIntersection
    {
        public static void Main()
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            string[] inputData = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            int rectanglesCount = int.Parse(inputData[0]);
            int checksCount = int.Parse(inputData[1]);

            for (int i = 0; i < rectanglesCount; i++)
            {
                string[] rectangleData = Console.ReadLine().Split();

                string id = rectangleData[0];
                double width = double.Parse(rectangleData[1]);
                double height = double.Parse(rectangleData[2]);
                double x = double.Parse(rectangleData[3]);
                double y = double.Parse(rectangleData[4]);

                Point topLeftPoint = new Point(x, y);
                Rectangle rectangle = new Rectangle(id, width, height, topLeftPoint);
                rectangles.Add(rectangle);
            }

            for (int i = 0; i < checksCount; i++)
            {
                string[] ractanglesToCheck = Console.ReadLine().Split();

                string firstRectangle = ractanglesToCheck[0];
                string secondRectangle = ractanglesToCheck[1];

                Console.WriteLine(rectangles.Find(x => x.Id == firstRectangle).CheckIfIntersect(rectangles.Find(y => y.Id == secondRectangle)));
            }            
        }
    }
}
