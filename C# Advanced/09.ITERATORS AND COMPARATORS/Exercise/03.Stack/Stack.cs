namespace P03Stack
{
    using System;
    using System.Linq;

    public class Stack
    {
        public static void Main()
        {
            var myCustomStack = new CustomStack<string>();

            while (true)
            {
                var command = Console.ReadLine();
                if (command?.ToLower() == "end")
                {
                    break;
                }

                var args = command.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

                if (command.StartsWith("Pop"))
                {
                    myCustomStack.Pop();
                }
                else
                {
                    myCustomStack.Push(args);
                }
            }

            Console.WriteLine(myCustomStack);
        }
    }
}
