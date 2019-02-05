namespace WordCount
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class wordCount
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> matches = new Dictionary<string, int>();

            using (var inputReader = new StreamReader(@"..\..\..\words.txt"))
            {
                string line = inputReader.ReadLine()?.ToLower();

                while (line != null)
                {
                    using (var outputReader = new StreamReader(@"..\..\..\text.txt"))
                    {
                        string outputLine = outputReader.ReadLine()?.ToLower();

                        while (outputLine != null)
                        {
                            if (outputLine.Contains(line))
                            {
                                if (!matches.ContainsKey(line))
                                {
                                    matches[line] = 0;
                                }
                                matches[line]++;
                            }

                            outputLine = outputReader.ReadLine()?.ToLower();
                        }
                    }

                    line = inputReader.ReadLine();
                }
            }

            var sortedMatches = matches.OrderByDescending(x => x.Value);


            using (var writer = new StreamWriter(@"..\..\..\actualResult.txt"))
            {
                foreach (var kvp in sortedMatches)
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }


            string actualText = File.ReadAllText(@"..\..\..\actualResult.txt");
            string expectedText = File.ReadAllText(@"..\..\..\expectedResult.txt");

            if (actualText == expectedText)
            {
                using (var writer = new StreamWriter(@"..\..\..\result.txt"))
                {
                    writer.WriteLine("actualResult.txt content: ");
                    writer.Write(actualText);
                    writer.WriteLine();

                    writer.WriteLine("expectedResult.txt content:");
                    writer.Write(expectedText);
                    writer.WriteLine();

                    writer.WriteLine("Result:");
                    writer.WriteLine(@"Both files are equal = True");                    
                }
            }
        }
    }
}
