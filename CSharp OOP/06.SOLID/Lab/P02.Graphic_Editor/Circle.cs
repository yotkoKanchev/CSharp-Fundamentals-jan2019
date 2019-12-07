namespace P02.Graphic_Editor
{
    public class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public string Draw()
        {
            return "I'm Circle";
        }
    }
}
