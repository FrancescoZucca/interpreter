using System;

namespace LinguLib
{
    public class Lexer
    {
        public static string[] LexLine(string line)
        {
            string[] subStringArg = new string[10];
            int currentArrayEntry = 0;
            string[] quotes = null;
            string[] tokens = null;
            int ini = 0; // NOTE to future self, was just a random name
            while (line.Contains('\"'))
            {
                if (line.Contains('\"'))
                {
                    quotes = line.Split('\"');
                    subStringArg[ini] = quotes[1];
                }

                if (subStringArg != null)
                {
                    line = line.Replace(quotes[1], "STRING");
                    line = line.Replace("\\", "");
                    line = line.Replace("\"", "");
                }
                ini++;
            }
            tokens = line.Split(' ');
            if (tokens[0] == "Output" && tokens[1] != "STRING")
            {
                tokens[1] = IO.OutputVariable(tokens[1]);
            }
            ini = 0;
            foreach (string i in tokens)
            {
                if (i == "STRING" && subStringArg != null)
                {
                    string value = i;
                    value = value.Replace("STRING", subStringArg[ini]);
                    tokens[currentArrayEntry] = value;
                }
                currentArrayEntry++;
                ini++;
            }
            return tokens;
        }
    }
}
