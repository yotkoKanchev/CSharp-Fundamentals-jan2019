namespace CarManufacturer
{
    class Car
    {
        string make;
        string model;
        int year;

        public Car()
        {
            this.Make = make;
            this.Model = model;
            this.Year = Year;
        }
        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int Year
        {
            get { return this.year; }
            set { year = value; }
        }
    }
}
