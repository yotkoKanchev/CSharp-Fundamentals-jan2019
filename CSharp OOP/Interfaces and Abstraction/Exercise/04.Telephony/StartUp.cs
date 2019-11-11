namespace P04.Telephony
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            var urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            var smartPhone = new Smartphone();

            phoneNumbers.ForEach(n => Console.WriteLine(smartPhone.Call(n)));
            urls.ForEach(u => Console.WriteLine(smartPhone.Browse(u)));
        }
    }
}
