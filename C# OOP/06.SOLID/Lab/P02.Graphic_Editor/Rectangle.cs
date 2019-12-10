namespace P02.Graphic_Editor
{
    public class Rectangle : IShape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public string Draw()
        {
            return "I'm Recangle";
        }
    }
}
