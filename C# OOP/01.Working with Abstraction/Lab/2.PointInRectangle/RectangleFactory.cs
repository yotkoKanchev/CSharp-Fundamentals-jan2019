namespace P2PointInRectangle
{
    using System;
    using System.Linq;

    public class RectangleFactory
    {
        private string args;
        public RectangleFactory(string args)
        {
            this.args = args;
        }

        public Rectangle Create()
        {
            var coorsArgs = this.args
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var topLeftX = coorsArgs[0];
            var topLeftY = coorsArgs[1];
            var bottomRightX = coorsArgs[2];
            var bottomRightY = coorsArgs[3];
            return new Rectangle(new Point(topLeftX, topLeftY), new Point(bottomRightX, bottomRightY));
        }
    }
}
