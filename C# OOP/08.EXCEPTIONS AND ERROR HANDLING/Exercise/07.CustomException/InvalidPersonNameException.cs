namespace P07.CustomException
{
    using System;
    using System.Linq;

    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException(string name)
            : base(name)
        {
        }               
    }
}
