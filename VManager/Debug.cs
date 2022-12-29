using System;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace Tools
{
    public static class Debug
    {
        public static void Info(string str, int lineNumber)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Debug: " + str);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Problem at: " + NameOfCallingClass() + " at line: " + lineNumber);
            Console.ResetColor();
        }
        private static string NameOfCallingClass()
        {
            string name;
            Type declaringType;
            int skipFrames = 2;
            do
            {
                MethodBase method = new StackFrame(skipFrames, false).GetMethod();
                declaringType = method.DeclaringType;
                if (declaringType == null)
                {
                    return method.Name;
                }
                skipFrames++;
                name = declaringType.FullName;
            }
            while (declaringType.Module.Name.Equals("mscorlib.dll", StringComparison.OrdinalIgnoreCase));
            return "\n" + name;
        }
        public static int LineNumber([System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0)
        {
            return lineNumber;
        }
    }
}