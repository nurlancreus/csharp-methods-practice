using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Service.Helpers
{
    public static class Logger
    {
        public static void ExceptionConsole(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(message);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void WarningConsole(string message)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(message);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void SuccessConsole(string message)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(message);
            Console.ResetColor();
            Console.WriteLine();

        }
    }
}
