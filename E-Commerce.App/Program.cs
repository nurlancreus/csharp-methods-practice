using E_Commerce.Service.Services.Implementations;

namespace E_Commerce.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MenuService menuService = new MenuService();
            //menuService.ShowMenu();

            List<int> ints = new List<int>();
            ints.Add(1);
            ints.Add(2);
            ints.Add(3);

            if(ints is ICollection<int> b)
            {
                foreach (var i in b)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
