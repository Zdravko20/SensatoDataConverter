namespace TableConverter.IO
{
    using System.Collections.Generic;
    using System.IO;
    using Contracts;

    public class FileInputReader : IInputReader
    {
        private string filePath = null;

        public FileInputReader(string filePath)
        {
            this.filePath = filePath;
        }

        public FileInputReader()
        {
            
        }

        public string FilePath { get { return this.filePath; } set { this.filePath = value; } }

        public string[] ReadInput()
        {
            List<string> allLines = new List<string>();
           
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    allLines.Add(line);
                    line = reader.ReadLine();
                }
            }

            return allLines.ToArray();
        }
    }
}
