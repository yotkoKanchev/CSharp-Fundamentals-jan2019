using System.Linq;

namespace P04.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string number)
        {
            if (number.Any(d => !char.IsDigit(d)))
            {
                return "Invalid number!";
            }

            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            if (url.Any(s => char.IsDigit(s)))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {url}!";
        }
    }
}
