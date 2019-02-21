namespace SoftUniParking
{
    using System.Text;

    public class Car
    {
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }

        public string Make { get => make; set => make = value; }
        public string Model { get => model; set => model = value; }
        public int HorsePower { get => horsePower; set => horsePower = value; }
        public string RegistrationNumber { get => registrationNumber; set => registrationNumber = value; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Make: {this.Make}");
            stringBuilder.AppendLine($"Model: {this.Model}");
            stringBuilder.AppendLine($"HorsePower: {this.HorsePower}");
            stringBuilder.Append($"RegistrationNumber: {this.RegistrationNumber}");

            return stringBuilder.ToString();
        }
    }
}
