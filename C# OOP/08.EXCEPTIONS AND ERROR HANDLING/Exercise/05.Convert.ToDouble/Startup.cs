namespace P05.Convert.ToDouble
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var value = Console.ReadLine();

            try
            {
                var result = Convert.ToDouble(value);
                Console.WriteLine($"Result is : {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch(OverflowException oe)
            {
                Console.WriteLine(oe.Message);
                throw oe;
            }
        }
    }
}
