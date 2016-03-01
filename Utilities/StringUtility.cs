using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Utilities
{
    public static class StringUtility
    {
        const int SleepTime = 7;

        public static void Color(string color)
        {
            switch (color.ToLower())
            {
                case "white": Console.ForegroundColor = ConsoleColor.White; break;
                case "red": Console.ForegroundColor = ConsoleColor.Red; break;
                case "blue": Console.ForegroundColor = ConsoleColor.Blue; break;
                case "green": Console.ForegroundColor = ConsoleColor.Green; break;
                case "yellow": Console.ForegroundColor = ConsoleColor.Yellow; break;
                case "gray": Console.ForegroundColor = ConsoleColor.Gray; break;
                case "cyan": Console.ForegroundColor = ConsoleColor.Cyan; break;
                case "magenta": Console.ForegroundColor = ConsoleColor.Magenta; break;
            }
        }

        public static void RollingText(string value)
        {
            foreach (char c in value)
            {
                Console.Write(c);
                Thread.Sleep(StringUtility.SleepTime);
            }
            Console.WriteLine();
        }
    }
}
