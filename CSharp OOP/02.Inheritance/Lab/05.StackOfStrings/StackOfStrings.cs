namespace CustomStack
{
    using System.Collections.Generic;
    using System.Linq;

    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count > 0;
        }

        public void AddRange(Stack<string> strings)
        {
            while (strings.Any())
            {
                this.Push(strings.Pop());
            }
        }
    }
}
