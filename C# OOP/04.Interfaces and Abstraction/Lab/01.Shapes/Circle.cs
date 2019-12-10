namespace Shapes
{
    using System;

    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            int radius = this.radius;
            double thickness = 0.4;
            char symbol = '*';

            double internalRadius = radius - thickness;
            double outlineRadius = radius + thickness;

            for (var y = radius; y >= -radius; --y)
            {
                for (double x = -radius; x < outlineRadius; x += 0.5)
                {
                    double value = (x * x) + (y * y);

                    if (value >= internalRadius * internalRadius &&
                        value <= outlineRadius * outlineRadius)
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
