namespace P03.DetailPrinter
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Manager : Employee
    {
        private string name;
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine(string.Join(Environment.NewLine, this.Documents));

            return sb.ToString().TrimEnd();
        }
    }
}
