using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LinguLib
{
    public class Variables
    {
        public static int[] amountOfVars = new int[3] { 0, 0, 0}; // num, string, bool; used when creating new vars, so starts at 0

        public static Number[] numberRegistry = new Number[875]; // orginally 70 (multiplied by 12.5x)  * \
        public static String[] stringRegistry = new String[250]; // originally 20 (multiplied by 12.5x) * - - > Variable capacity
        public static Boolean[] boolRegistry = new Boolean[1188]; // orginally 95 (multiplied by 12.5x) * /

        // Declaration of classes. Each class has a common and unique |
        // attribute. Common is the name, which is a string, but the  |
        // unique is the variable with the type that corresponds to   |
        // the class, which is value of variables                    \_/

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
            public string Name;
            public bool Value;
        }

        // Functions for creating new variables |
        // Each function except for string has  |
        // a conversion from string input      \_/

        public static void NewNumber(string name, string value = "")
        {
            double val = 26.34;
            try
            {
                val = Convert.ToDouble(value); // When values come from the Lingu source, they are all strings. They need to be converted in order to be stored.
            }
            catch
            {
                throw new InvalidDataException("Invalid value for variable of Number type");
            }
            numberRegistry[amountOfVars[0]] = new Number(name, val); 
            amountOfVars[0]++; // Updating variables count
        }

        public static void NewBoolean(string name, string value = "")
        {
            bool boolValue = false;
            switch (value) // "They need to be converted in order to be stored." Same here. More code, but more stable process
            {
                case "true":
                    boolValue = true;
                    break;

                case "false":
                    boolValue = false;
                    break;

                default:
                    throw new InvalidDataException("Internal or syntax error");
            }
            boolRegistry[amountOfVars[2]] = new Boolean(name, boolValue);
            amountOfVars[2]++; // Updating variables count
        }

        public static void NewString(string name, string value = "")
        {
            stringRegistry[amountOfVars[1]] = new String(name, value); // No conversion is needed here
            amountOfVars[1]++; // Updating variables count
        }

        public static void NewVariableValue(string name, string value)
        {
            int c = 0; // current object in the array, since you can't change 'i' directly
            foreach (String i in stringRegistry)
            {
                if (i.Name == name)
                {
                    stringRegistry[c].Value = value; // if the current variables's name matches what we need, assign new value
                }
                c++; // also, humor!
            }
            

            // This process is repeated for every variable type in Lingu, with type-specific alterations

            c = 0;
            foreach (Number i in numberRegistry)
            {
                if (i.Name == name)
                {
                    numberRegistry[c].Value = Convert.ToDouble(value);
                }
                c++;
            }

            c = 0;
            foreach (Boolean i in boolRegistry)
            {
                if (i.Name == name)
                {
                    bool boolValue = false;
                    switch (value) // Same robust method as above
                    {
                        case "true":
                            boolValue = true;
                            break;

                        case "false":
                            boolValue = false;
                            break;

                        default:
                            throw new InvalidDataException("Internal or syntax error");
                    }
                    boolRegistry[c].Value = boolValue;
                }
                c++;
            }
        }
    }
}
