using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguLib
{
    public class IO 
    { 
        public static string OutputVariable(string varName)
        {
            string value = "";
            foreach (Variables.Number i in Variables.numberRegistry)
            {
                try
                {
                    if (i != null && i.Name == varName)
                    {
                        value = Convert.ToString(i.Value);
                        break;
                    }
                }
                catch { break; }
            }
            foreach (Variables.String i in Variables.stringRegistry)
            {
                try
                {
                    if (i != null && i.Name == varName)
                    {
                        value = i.Value;
                    }
                    else if (i == null)
                    {
                        break;
                    }
                    else
                    {
                        throw new InvalidOperationException("Unexpected (and unknown) error.");
                    }
                }
                catch { break; }
            }
            foreach (Variables.Boolean i in Variables.boolRegistry)
            {
                try
                {
                    if (i != null && i.Name == varName)
                    {
                        value = Convert.ToString(i.Value);
                    }
                }
                catch { break; }
            }
            return value;
        }

        public static void InputVariable(string varName)
        {
            string value = Console.ReadLine();
            int? type = null; // should be 0 for number, 1 for string, 2 for boolean (just like amountOfVars[]).
            // Initialized ^ with null to keep compiler errors out of the way
            int c = 0; // current array entry; will be useful in switch statement
            foreach (Variables.Number i in Variables.numberRegistry)
            {
                try
                {
                    if (i != null && i.Name == varName)
                    {
                        type = 0;
                        goto Switch;
                    }
                    else if (!(i != null)) // if i is null then break
                    {
                        break;
                    }
                }
                catch { break; }
            }
            foreach (Variables.String i in Variables.stringRegistry)
            {
                try
                {
                    if (i != null && i.Name == varName)
                    {
                        type = 1;
                        goto Switch;
                    }
                    else if (i == null) // if i is null then break
                    {
                        break;
                    }
                }
                catch { break; }
            }
            foreach (Variables.Boolean i in Variables.boolRegistry)
            {
                try
                {
                    if (i != null && i.Name == varName)
                    {
                        type = 2;
                        goto Switch;
                    }
                    else if (!(i != null)) // if i is null then break
                    {
                        break;
                    }
                }
                catch { break; }
            }

            /* After evaluating what type of variable we are dealing with, * 
             * then we can convert our value and then assign accordingly.  */

            Switch:;
            switch (type)
            {
                case 0: // Case we are dealing with numbers
                    Variables.numberRegistry[c].Value = Convert.ToDouble(value); // simple
                    break;

                case 1: // Case we are dealing with strings
                    Variables.stringRegistry[c].Value = value; // simplest
                    break;

                case 2: // Case we are dealing with booleans
                    Variables.boolRegistry[c].Value = Convert.ToBoolean(value); // don't tease me for being inconsistent, ok?
                    break;

                default: // And throw an exception
                    throw new NoNullAllowedException("Variable doesn't exist.");
            }
        }
    }
}
