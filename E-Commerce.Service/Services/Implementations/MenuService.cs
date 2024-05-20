using E_Commerce.Service.Helpers;
using E_Commerce.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Services.Implementations
{
    public class MenuService : IMenuService
    {
        private static void SubMenu(IService service)
        {

            //string type = service.GetType().Name.Split("Service")[0];

            // Get the type name of the service
            string typeName = service.GetType().Name;

            // Remove "Service" from the end of the type name
            string typeWithoutService = typeName.EndsWith("Service")
                ? typeName.Substring(0, typeName.Length - "Service".Length)
                : typeName;

            // Now 'typeWithoutService' will contain the part of the type name before "Service"
            string type = typeWithoutService;

            bool isOperationsDone = false;

            while (!isOperationsDone)
            {
                Console.WriteLine($"1.Add {type}.\n" +
                    $"2.Update {type}.\n" +
                    $"3.Delete {type}.\n" +
                    $"4.Get {type} by Id.\n" +
                    $"5.Get All {type}s.\n" +
                    $"0.Exit {type} Menu");
                Console.Write("Enter operation number: ");
                int.TryParse(Console.ReadLine(), out int userChoice);

                switch (userChoice)
                {
                    case 1:
                        service.Add();
                        break;
                    case 2:
                        service.Update();
                        break;
                    case 3:
                        service.Delete();
                        break;
                    case 4:
                        service.GetById();
                        break;
                    case 5:
                        service.GetAll();
                        break;
                    case 0:
                        isOperationsDone = true;
                        break;
                    default:
                        Logger.ExceptionConsole("Enter valid operation number!!!");
                        break;

                }

            }

        }

        public void ShowMenu()
        {
            bool isOperationsDone = false;

            while (!isOperationsDone)
            {
                Console.WriteLine(
                     "1.Customer Menu\n" +
                     "2.Shop Menu\n" +
                     "3.Product Menu\n" +
                     "4.Product Category Menu\n" +
                     "0.Exit Program");

                Console.Write("Enter operation number: ");
                int.TryParse(Console.ReadLine(), out int userChoice);

                switch (userChoice)
                {
                    case 1:
                        ICustomerService customerService = new CustomerService();
                        SubMenu(customerService);
                        break;
                    case 2:
                        IShopService shopService = new ShopService();
                        SubMenu(shopService);
                        break;
                    case 3:
                        IProductService productService = new ProductService();
                        SubMenu(productService);
                        break;
                    case 4:
                        IProductCategoryService productCategoryService = new ProductCategoryService();
                        SubMenu(productCategoryService);
                        break;
                    case 0:
                        isOperationsDone = false;
                        break;
                    default:
                        Logger.ExceptionConsole("Enter valid operation number!!!");
                        break;

                }
            }
        }
    }
}
