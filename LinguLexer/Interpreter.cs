using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguLib
{
    public class Interpreter
    {
        public static void Interpret(string[] input)
        {
            switch (input[0])
            {
                case "Output":
                    if (input[2] == "to" && input[3] == "Console.")
                    {
                        Console.WriteLine(input[1]);
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
