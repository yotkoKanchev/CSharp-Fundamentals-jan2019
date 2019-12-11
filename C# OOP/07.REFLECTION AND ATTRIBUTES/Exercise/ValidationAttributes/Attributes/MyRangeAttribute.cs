namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        public int minValue;
        public int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        public override bool IsValid(object obj)
        {
            if ((int)obj >= minValue && (int)obj <= maxValue)
            {
                return true;
            }

            return false;
        }
    }
}
