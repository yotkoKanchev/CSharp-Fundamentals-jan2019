using System.Text;

namespace _10.CarSalesman
{
    public class Engine
    {
        private string engineModel;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.engineModel = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement)
            : this(model, power, displacement, "n/a")
        {                
        }

        public Engine(string model, int power, string color)
            : this(model, power, -1, color)
        {            
        }

        public Engine(string color, int power)
            : this(color,power, -1, "n/a")
        {            
        }

        public string EngineModel { get { return this.engineModel; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"  {this.engineModel}:");
            sb.AppendLine($"    Power: {this.power}");
            if (this.displacement == -1)
            {
                sb.AppendLine($"    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {this.displacement}");
            }
            sb.Append($"    Efficiency: {this.efficiency}");

            return sb.ToString();
        }
    }
}
