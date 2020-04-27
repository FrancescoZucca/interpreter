using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LinguLib
{
    public class Variables
    {
        public static int[] amountOfVars = { 0, 0, 0}; // num, string, bool
        public static Number[] numberRegistry;
        public static String[] stringRegistry;
        public static Boolean[] boolRegistry;

        public class Number
        {
            public Number(string name, double value)
            {
                Name = name;
                Value = value;
            }
            public string Name;
            public double Value;
        }

        public class String
        {
            public String(string name, string value)
            {
                Name = name;
                Value = value;
            }
            public string Name;
            public string Value;
        }

        public class Boolean
        {
            public Boolean(string name, bool value)
            {
                Name = name;
                Value = value;
            }
            public string Name { get; }
            public bool Value { get; }
        }

        public static void NewNumber(string name, string value = "")
        {
            double val = 26.34;
            try
            {
                val = Convert.ToDouble(value);
            }
            catch
            {
                Console.WriteLine("Invalid value for variable of Number type");
            }
            numberRegistry[amountOfVars[0]] = new Number(name, val); 
            amountOfVars[0]++;
        }

        public static void NewBoolean(string name, string value = "")
        {
            bool boolValue = false;
            switch (value)
            {
                case "true":
                    boolValue = true;
                    break;

                case "false":
                    boolValue = false;
                    break;

                default:
                    Console.WriteLine("Internal or syntax error");
                    break;
            }
            boolRegistry[amountOfVars[2]] = new Boolean(name, boolValue);
            amountOfVars[2]++;
        }

        public static void NewString(string name, string value = "")
        {
            stringRegistry[amountOfVars[1]] = new String(name, value);
            amountOfVars[1]++;
        }


    }
}
