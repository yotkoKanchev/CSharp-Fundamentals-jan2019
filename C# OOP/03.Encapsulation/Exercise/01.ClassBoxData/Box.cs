using System;
using System.Text;

namespace P01ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                ValidateSide(value, nameof(Length));
                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                ValidateSide(value, nameof(Width));
                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                ValidateSide(value, nameof(Height));
                this.height = value;
            }
        }

        private void ValidateSide(double value, string type)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{type} cannot be zero or negative.");
            }
        }

        private double CalculateSurfaceArea()
        {
            return 2 * (this.Length * this.Width) + 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);
        }

        private double CalculateLateralSurfaceArea()
        {
            return 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        private double CalculateVolume()
        {
            return this.Height * this.Width * this.Length;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.CalculateSurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.CalculateLateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {this.CalculateVolume():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
