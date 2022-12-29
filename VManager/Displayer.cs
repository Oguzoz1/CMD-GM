using System;
using System.Collections.Generic;
using System.Text;

namespace Tools
{
    class Displayer
    {
        public static void WriteLine(string str, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        public static void Write(string str, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.Write(str);
            Console.ResetColor();
        }
    }
}
