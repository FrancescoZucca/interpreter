using System;
using System.Collections.Generic;
using System.Data;
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
                case "Comment":
                    break;

                case "Output":
                    if (input[2] == "to" && input[3] == "Console.")
                    {
                        Console.WriteLine(input[1]);
                    }
                    if (input[1] == "the" && input[2] == "value" && input[3] == "of" && input[4] == "variable" && input[6] == "to" && input[7] == "Console")
                    {
                        IO.OutputVariable(input[5]);
                    }
                    break;

                case "Get":
                    switch (input[1])
                    {
                        case "input":
                            if (input[2] == "and" && input[3] == "store" && input[4] == "in")
                            {
                                
                            }
                            break;
                        case "input.":
                            Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("invalid syntax for Get.");
                            break;
                    }
                    break;

                case "New":
                    if (input[2] == "of" && input[3] == "name")
                    {
                        switch (input[1])
                        {
                            case "string":
                                if (input[5] == "with" && input[6] == "value" && input[7].Contains('.'))
                                {
                                    Variables.NewString(input[4], input[7]);
                                }
                                else if (input[4].Contains('.'))
                                {
                                    Variables.NewString(input[4]);
                                }
                                break;

                            case "boolean":
                                if (input[5] == "with" && input[6] == "value" && input[7].Contains('.'))
                                {
                                    Variables.NewBoolean(input[4], input[7]);
                                }
                                else if (input[4].Contains('.'))
                                {
                                    Variables.NewBoolean(input[4]);
                                }
                                break;

                            case "number":
                                if (input[5] == "with" && input[6] == "value" && input[7].Contains('.'))
                                {
                                    Variables.NewNumber(input[4], input[7]);
                                }
                                else if (input[4].Contains('.'))
                                {
                                    Variables.NewNumber(input[4]);
                                }
                                break;
                        }
                    }
                    break;

                default:
                    throw new SyntaxErrorException("Invalid syntax.");
            }
        }
    }
}
