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
        // Nothing much here. Just some functions to  |
        // have the least amount of code in the front |
        // end interaction logic. Oneline methods.   \_/
        
        public static void Lexterpret(string input)
        {
            Interpreter.Interpret(Lexer.LexLine(input));
        }

        public static void LexterpretFile(string filePath)
        {
            string line;
            try {
                StreamReader o = new StreamReader(filePath);
                while ((line = o.ReadLine()) != null){
                    Lexterpret(line);
                }
            }catch (FileNotFoundException)
            {
                //TODO: add FNF handling
            }
        }
    } 
}
