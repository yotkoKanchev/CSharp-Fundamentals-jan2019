namespace P2PointInRectangle
{
    using System;
    using System.Linq;

    public class PointFactory
    {
        private string args;

        public PointFactory(string args)
        {
            this.args = args;
        }

        public Point Create()
        {
            var pointArgs = this.args
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var pointX = pointArgs[0];
            var pointY = pointArgs[1];

            return new Point(pointX, pointY);
        }
    }
}
