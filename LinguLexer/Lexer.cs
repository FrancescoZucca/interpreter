using System;

namespace LinguLib
{
    public class Lexer
    {
        public static string[] LexLine(string line)
        {
            int verificitate = 0;
            string subStringArg = null;
            int currentArrayEntry = 0;
            string[] quotes = null;
            string[] tokens = null;
                if (line.Contains('\"'))
                {
                    quotes = line.Split('\"');
                    subStringArg = quotes[1];
                }
                if (subStringArg != null)
                {
                    line = line.Replace(quotes[1], "STRING");
                    verificitate = 1;
                    line = line.Replace("\\", "");
                    line = line.Replace("\"", "");
                }
                tokens = line.Split(' ');
                foreach (string i in tokens)
                {
                    if (i == "STRING" && subStringArg != null && verificitate == 1)
                    {
                        string value = i;
                        value = value.Replace("STRING", subStringArg);
                        tokens[currentArrayEntry] = value;
                    }
                    currentArrayEntry++;
                }
            return tokens;
        }
    }
}
