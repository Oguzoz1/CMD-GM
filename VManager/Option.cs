using System;
using System.Collections.Generic;
using System.Text;
using Tools;

namespace MainThread
{
    public class Option
    {
        string[] options;
        string optionHeadLine;
        string answer;
        ConsoleColor color;
        public void DisplayOptions(string[] x, string optionHeadLine,string answer,ConsoleColor colour)
        {
            options = x;
            this.optionHeadLine = optionHeadLine;
            this.answer = answer;
            color = colour;

            Displayer.WriteLine(optionHeadLine, colour);
            ListOptions(x, colour);
        }
        public string ReturnSelectedOption()
        {
            //Check if displayoption has filled references.
            if (options.Length == 0 ||string.IsNullOrWhiteSpace(optionHeadLine) || string.IsNullOrWhiteSpace(answer))
            { Debug.Info("CALL OPTION.DISPLAYOPTIONS FIRST!!", Debug.LineNumber()); return null; }

            int numberOfOptions = options.Length;
            string nextInput = Console.ReadLine();
            int option = 0;
            //Check Input if digit or not
            if (nextInput.IsOnlyDigits()) option = Convert.ToInt16(nextInput);
            else { Displayer.WriteLine("PLEASE ENTER A DIGIT", ConsoleColor.Red); return null; }

            if (option <= numberOfOptions && option > 0)
            {
                return ComparasionResult(numberOfOptions,option);
            }
            else 
            { 
                Displayer.WriteLine(option + " It's out of range!", ConsoleColor.Red); 
                return null;
            }
            
        }
        private string ComparasionResult(int numberOfOptions, int option)
        {
            for (int i = 0; i < numberOfOptions; i++)
            {
                if ((option - 1) == i)
                {
                    Displayer.WriteLine(answer, color);
                    return options[i];
                }
            }
            return null;
        }
        private void ListOptions(string[] x, ConsoleColor colour)
        {
            for (int i = 0; i < x.Length; i++)
            {
                Displayer.WriteLine("\n" + (i + 1) + "-" + x[i], colour);
            }
        }
    }
}