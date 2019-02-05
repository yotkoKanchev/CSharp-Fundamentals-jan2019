namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    class evenLines
    {
        static void Main(string[] args)
        {
            char[] symbolsToReplace = new char[] {'-',',','.','!','?'};
            int counter = 0;

            using (var reader = new StreamReader(@"..\..\..\text.txt"))
            {       
                using (var writer = new StreamWriter(@"..\..\..\output.txt"))
                {
                    string line = reader.ReadLine();
                    
                    while (line != null)
                    {
                        if (counter % 2 == 0)
                        {
                            for (int i = 0; i < line.Length; i++)
                            {
                                if (symbolsToReplace.Contains(line[i]))
                                {
                                    line = line.Replace(line[i], '@');
                                }
                            }
                            
                            string[] lineAsArray = line.Split();
                            Array.Reverse(lineAsArray);
                            line = string.Join(" ", lineAsArray);
                            writer.WriteLine(line);
                        }
                        counter++;

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}

