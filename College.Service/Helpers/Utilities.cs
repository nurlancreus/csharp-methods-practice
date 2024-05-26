using College.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Service.Helpers
{
    public static class Utilities
    {
        public static double ReadNumber(string text)
        {
            while (true)
            {
                try
                {
                    Console.Write(text);
                    if (double.TryParse(Console.ReadLine(), out double result))
                    {
                        return result;
                    }
                    else throw new FormatException("Please, enter the right format data");

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
                    Console.Write(text);
                    string? result = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(result)) return result;
                    else throw new FormatException("Please, enter the right format data");

                }
                catch (FormatException ex)
                {
                    Logger.ExceptionConsole(ex.Message);
                }
            }
        }

        public static string FormatGrade(Grade grade)
        {
            return grade.ToString().Replace("_Plus", "+").Replace("_Minus", "-");
        }
    }
}
