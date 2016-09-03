namespace TableConverter
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class InputValidator
    {
        private const string Pattern = @"((\+\d{1,2}\,){3}(---,)+)+((\+\d{1,2}\,){3}(---,)+(\+\d{1,2},)?(---,)+)?([0-9]|0[0-9]|1[0-9]|2[0-3])h(.+)";
        private Regex regex = new Regex(Pattern);

        public string[] ParseValideLines(string[] allLines)
        {
            List<string> validLines = new List<string>();
            foreach (var line in allLines)
            {
                if (this.regex.IsMatch(line))
                {
                    validLines.Add(line);
                }
            }

            return validLines.ToArray();
        }
    }
}
