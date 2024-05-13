using BoltFood.Service.Helpers.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Helpers.Extensions
{
    public static class ReadNumberExtension
    {
        public static double ReadNumber(this double value, string message, string exMessage = "Please enter the correct format.")
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    double num = Convert.ToDouble(Console.ReadLine());
                    return num;
                }
                catch (FormatException)
                {
                    Utilities.Utilities.ExceptionConsole(exMessage);
                }
            }
        }
    }
}
