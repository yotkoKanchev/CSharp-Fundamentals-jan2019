namespace _08.Threeuple
{
    public class Threeuple<I1, I2, I3>
    {
        public Threeuple(I1 item1, I2 item2, I3 item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        public I1 Item1 { get; set; }
        public I2 Item2 { get; set; }
        public I3 Item3 { get; set; }


        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
        }
    }
}
