using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace E_Commerce.Service.Helpers
{
    public static class Utilities
    {
        public static double ReadNumber(string text)
        {
            while (true)
            {
                try
                {
                    Console.Write(text + ": ");

                    double number = Convert.ToDouble(Console.ReadLine());
                    return number;
                }

                catch (FormatException ex)
                {
                    Logger.ExceptionConsole(ex.Message);
                }
            }
        }

        public static string ReadString(string text)
        {
            while (true)
            {
                try
                {
                    Console.Write(text + ": ");
                    string? input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new FormatException("Please, provide correct format data");
                    }
                    else return input;
                }
                catch (FormatException ex)
                {
                    Logger.ExceptionConsole(ex.Message);
                }

            }
        }
    }
}
