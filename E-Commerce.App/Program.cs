using E_Commerce.Service.Services.Implementations;

namespace E_Commerce.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuService menuService = new MenuService();
            menuService.ShowMenu();
        }
    }
}
