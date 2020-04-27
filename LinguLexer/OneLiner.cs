using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.Tracing;

namespace LinguLib
{
    public class OneLiner
    {
        public static void Lexterpret(string input)
        {
            Interpreter.Interpret(Lexer.LexLine(input));
        }

        public static void LexterpretFile(string filePath)
        {
            int counter = 0;
            string line;
            StreamReader o = new StreamReader(filePath);
            while ((line = o.ReadLine()) != null)
            {
                Lexterpret(line);
            }
        }
    } 
}
