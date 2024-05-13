using BoltFood.Data.Repositories.Implementations;
using BoltFood.Service.Helpers.Extensions;
using BoltFood.Service.Helpers.Utilities;
using BoltFood.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Implementations
{
    public class MenuService : IMenuService
    {
        private RestaurantRepository restaurantRepo = new RestaurantRepository();
        public void ShowRestaurantMenu()
        {
            bool exitMenu = false;
            RestaurantService restaurantService = new RestaurantService();

            while (!exitMenu)
            {
                Console.WriteLine("1.Add a restaurant\n2.Get All restaurants\n3.Get a restaurant by Id\n4.Update a restaurant.\n5.Delete a restaurant\n6.Go Back\n0.Exit");
                int userChoice = (int)((double)0).ReadNumber("Please enter the menu number: ");
                switch (userChoice)
                {
                    case 1:
                        restaurantService.Add();

                        break;
                    case 2:
                        restaurantService.GetAll();
                        break;
                    case 3:
                        restaurantService.GetById();
                        break;
                    case 4:
                        restaurantService.Update();
                        break;
                    case 5:
                        restaurantService.Delete();
                        break;
                    case 6:
                        ShowMenu();
                        break;
                    case 0:
                        Console.WriteLine("Exit Restaurant Menu...");
                        Thread.Sleep(2000);
                        exitMenu = true;
                        break;
                    default:
                        Utilities.ExceptionConsole("Enter a valid Choice");
                        break;
                }
            }

        }
        public void ShowProductMenu()
        {

            bool exitMenu = false;

            ProductService productService = new ProductService();

            while (!exitMenu)
            {
                Console.WriteLine("1.Add a product\n2.Get All products\n3.Get a product by Id\n4.Update a product.\n5.Delete a product\n6.Get products by restautant Id.\n7.Go Back\n0.Exit");
                int userChoice = (int)((double)0).ReadNumber("Please enter the menu number: ");

                switch (userChoice)
                {
                    case 1:
                        if (restaurantRepo.IfAny()) productService.Add();
                        else throw new Exception("There is no restaurant begin with, please first create a restaurant");

                        break;
                    case 2:
                        productService.GetAll();
                        break;
                    case 3:
                        productService.GetAll();
                        break;
                    case 4:
                        productService.Update();
                        break;
                    case 5:
                        productService.Delete();
                        break;
                    case 6:
                        productService.GetProductsByRestaurantId();
                        break;
                    case 7:
                        ShowMenu();
                        break;
                    case 0:
                        Console.WriteLine("Exit Product Menu...");
                        Thread.Sleep(2000);
                        exitMenu = true;
                        break;
                    default:
                        Utilities.ExceptionConsole("Enter a valid Choice");
                        break;
                }
            }

        }

        public void ShowMenu()
        {
            bool isContinue = true;

            while (isContinue)
            {
                Console.WriteLine("Welcome to Bolt Food\n1.Restaurant Menu\n2.Products Menu");
                Console.Write("Enter step: ");
                int step = (int)((double)0).ReadNumber("Please enter step: ");

                switch (step)
                {
                    case 1:
                        ShowRestaurantMenu();
                        break;
                    case 2:
                        ShowProductMenu();
                        break;
                    case 0:
                        isContinue = false;
                        break;
                    default:
                        Utilities.ExceptionConsole("Enter a valid Choice");
                        break;
                }
            }

        }
    }
}
