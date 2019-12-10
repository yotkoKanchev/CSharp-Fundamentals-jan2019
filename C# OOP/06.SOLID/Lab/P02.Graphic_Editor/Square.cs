namespace P02.Graphic_Editor
{
    public class Square : IShape
    {
        private double side;

        public Square(double side)
        {
            this.side = side;
        }

        public string Draw()
        {
            return "I'm Square";
        }
    }
}
