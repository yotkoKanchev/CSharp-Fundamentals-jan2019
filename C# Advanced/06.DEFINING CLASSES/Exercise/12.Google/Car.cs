using System.Text;

namespace _12.Google
{
    public class Car
    {
        public Car(string model, double speed)
        {
            this.Model = model;
            this.Speed = speed;
        }

        public string Model { get; set; }
        public double Speed { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Car:");
            if (this.Model != string.Empty)
            {
                stringBuilder.AppendLine();
                stringBuilder.Append($"{this.Model} {this.Speed}");
            }

            return stringBuilder.ToString();
        }
    }
}
