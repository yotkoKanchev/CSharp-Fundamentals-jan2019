namespace P02.Graphic_Editor
{
    using System;

    public class GraphicEditor
    {
        private IShape shape;

        public GraphicEditor(IShape shape)
        {
            this.shape = shape;
        }

        public void DrawShape(IShape shape)
        {
            Console.WriteLine(this.shape.Draw());
        }
    }
}
