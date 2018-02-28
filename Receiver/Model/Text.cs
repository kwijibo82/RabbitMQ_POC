using Receiver.Interfaces;
using System;

namespace Receiver.Model
{
    public class Text : IText
    {
        public string _String { get; set; }

        public void highlightText(string color)
        {
            if (color.Equals("red"))
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else if (color.Equals("blue"))
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            else if (color.Equals("green"))
            {
                Console.BackgroundColor = ConsoleColor.Green;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void unHighlightText()
        {
            Console.ResetColor();
        }

        public void write(string str)
        {
            Console.Write(str);
        }
    }
}
