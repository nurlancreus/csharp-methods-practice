using College.Service.Services.Implementations;

namespace College.App
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            MenuService menuService = new MenuService();
            await menuService.ShowMenuAsync();
        }
    }
}
