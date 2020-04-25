using System;

namespace LinguLexer
{
    public class Lexer
    {
        public string[] Lex(string line)
        {
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
            }
            string[] tokens = line.Split(' ');
            foreach (string i in tokens)
            {
                if (i == "STRING" && subStringArg != null)
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

    public class Interpreter
    {
        public void Interpret(string[] line)
        {

        }
    }
}
