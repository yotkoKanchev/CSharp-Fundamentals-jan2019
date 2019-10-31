namespace P2PointInRectangle
{
    using System;
    using System.Linq;

    public class PointInRectangle
    {
        public static void Main()
        {
            var rectangle = new RectangleFactory(Console.ReadLine()).Create();

            var pointsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < pointsCount; i++)
            {
                var point = new PointFactory(Console.ReadLine()).Create();
                
                Console.WriteLine(rectangle.CheckPointIsInside(point));
            }
        }
    }
}
