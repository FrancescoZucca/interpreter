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
            if (line.Contains('\"'))
            {
                string[] quotes = line.Split('\"');
                subStringArg = quotes[1];
            }
            if (subStringArg != null)
            {
                line.Replace(subStringArg, "STRING");
                verificitate = 1;
            }
            string[] tokens = line.Split(' ');
            foreach (string i in tokens)
            {
                if (i == "STRING" && subStringArg != null && verificitate == 1)
                {
                    string value = i;
                    value.Replace("STRING", subStringArg);
                    tokens[currentArrayEntry] = value;
                }
                currentArrayEntry++;
            }
            return tokens;
        }
    }
}
