using BoltFood.Service.Helpers.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Helpers.Extensions
{
    public static class ReadStringExtension
    {
        public static string ReadString(this string value, string message)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                        throw new FormatException();

                    return input;
                }
                catch (FormatException)
                {
                    Utilities.Utilities.ExceptionConsole("Please input text, not white space");

                }
            }
        }
    }
}