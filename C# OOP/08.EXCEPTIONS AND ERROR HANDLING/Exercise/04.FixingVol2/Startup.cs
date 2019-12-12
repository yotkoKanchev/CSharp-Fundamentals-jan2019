namespace P04.FixingVol2
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            int num1, num2;

            byte result;

            num1 = 30;
            num2 = 60;

            try
            {
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine("{} x {} = {}", num1, num2, result);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }
    }
}
