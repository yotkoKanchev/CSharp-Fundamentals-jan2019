using System;

namespace P2PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }

        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public bool CheckPointIsInside(Point point)
        {
            var check = this.CheckHorizontaly(point.X) && this.CheckVerticaly(point.Y);
            return check ;
        }

        private bool CheckVerticaly(int y)
        {
            return this.TopLeft.Y <= y && this.BottomRight.Y >= y;
        }

        private bool CheckHorizontaly(int x)
        {
            return this.TopLeft.X <= x && this.BottomRight.X >= x;
        }
    }
}
