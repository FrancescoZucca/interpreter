using System;
using System.Text.Json;

namespace LinguLib
{
    public class Lexer // version v0.3a
    {
        public static string[] LexLine(string line)
        {
            if (line.StartsWith("#"))
            {
                goto Comment;
            }
            string[] tokens;
            string[] subStrings = new string[10];
            string[] varCache = new string[10];
            int c = 0; // <-- because I can, 'i' was taken in the context this is used, and doing 'c++' is humorous
            int i = 0;

            while (line.Contains('\"'))
            {
                int startPos = 0;
                int endPos = 0;
                try
                {
                    char[] fragments = line.ToCharArray();
                    // getting char positions
                    foreach (Char curr in fragments)
                    {
                        if (curr == '\"')
                        {
                            break;
                        }
                        startPos++;
                    }
                    foreach (Char curr in fragments)
                    {
                        if (curr == '\"' && endPos != startPos)
                        {
                            break;
                        }
                        endPos++;
                    }
                    subStrings[i] = line.Substring(startPos, (endPos - startPos));
                    line = line.Replace(subStrings[i], "STRING-" + i); // signals that a string is supposed to be there, and gives an identifier
                    line = line.Replace(("-" + i + "\""), ("-" + i));
                }
                catch
                {
                    break;
                }
                i++;
            }

            // Main point. String resolution comes before //
            /********/ tokens = line.Split(' '); /********/
            // String replacement comes after /**********/

            foreach (String curr in tokens)
            {
                if (curr.Contains("STRING-"))
                {
                    string linee = curr; // linee because line was taken
                    string[] temp //<-- "temporary"
                    = curr.Split('-');
                    temp[1] = temp[1].Replace(".", "").Replace("\"", "");
                    int id = Convert.ToInt32(temp[1]);
                    linee = linee.Replace(curr, subStrings[id]);
                    linee.Replace("\"", "");
                    tokens[c] = linee;
                }
                c++;
            }

            return tokens;
        Comment:;
            tokens = new string[1];
            tokens[0] = "Comment";
            return tokens;
        }
    }
}
