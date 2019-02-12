namespace _09.RectangleIntersection
{
    public class Rectangle
    {
        private string id;
        private double width;
        private double height;
        private Point topLeftPoint;

        public Rectangle(string id, double width, double height, Point topLeftPoint)
        {
            this.id = id;
            this.width = width;
            this.height = height;
            this.topLeftPoint = topLeftPoint;
        }

        public string Id { get { return this.id; } }

        public string CheckIfIntersect(Rectangle secondRectangle)
        {
            if (this.topLeftPoint.X + this.width < secondRectangle.topLeftPoint.X
                || secondRectangle.topLeftPoint.X + secondRectangle.width < this.topLeftPoint.X
                || this.topLeftPoint.Y + this.height < secondRectangle.topLeftPoint.Y
                || secondRectangle.topLeftPoint.Y + secondRectangle.height < this.topLeftPoint.Y)
            {
                return "false";
            }
            return "true";
        }
    }
}
