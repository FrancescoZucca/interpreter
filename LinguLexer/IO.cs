using System;
using System.Collections.Generic;
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
                if (i.Name == varName)
                {
                    value = Convert.ToString(i.Value);
                    break;
                }
            }
            foreach (Variables.String i in Variables.stringRegistry)
            {
                if (i.Name == varName)
                {
                    value = i.Value;
                }
            }
            foreach (Variables.Boolean i in Variables.boolRegistry)
            {
                if (i.Name == varName)
                {
                    value = Convert.ToString(i.Value);
                }
            }
            return value;
        }
    }
}
