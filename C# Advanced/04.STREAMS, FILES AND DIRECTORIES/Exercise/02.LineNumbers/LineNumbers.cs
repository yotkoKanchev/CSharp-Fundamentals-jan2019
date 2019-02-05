namespace LineNumbers
{
    using System.IO;

    class lineNumbers
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"..\..\..\text.txt"))
            {
                int counter = 1;

                using (var writer = new StreamWriter(@"..\..\..\output.txt"))
                {
                    string line = reader.ReadLine();
                    
                    while (line != null)
                    {
                        int characters = 0;
                        int punctMarks = 0;

                        foreach (var symbol in line)
                        {
                            if (char.IsLetter(symbol))
                            {
                                characters++;
                            }
                            else if (!char.IsLetterOrDigit(symbol) && symbol != ' ')
                            {
                                punctMarks++;
                            }
                        }

                        writer.WriteLine($"Line {counter}: {line} ({characters})({punctMarks})");
                        counter++;

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
