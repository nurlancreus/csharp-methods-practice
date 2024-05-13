using BoltFood.Service.Helpers.Utilities;
using BoltFood.Service.Services.Implementations;
using System.ComponentModel.Design;

namespace BoltFood
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                MenuService menuservice = new MenuService();

                menuservice.ShowMenu();
            }
            catch (Exception ex)
            {
                Utilities.ExceptionConsole(ex.Message);
            }


        }
    }
}
