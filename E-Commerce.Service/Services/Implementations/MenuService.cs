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

            CustomerService customerService = new CustomerService();

            //string type = service.GetType().Name.Split("Service")[0];

            // Get the type name of the service
            string typeName = service.GetType().Name;

            // Remove "Service" from the end of the type name
            string typeWithoutService = typeName.EndsWith("Service")
                ? typeName.Substring(0, typeName.Length - "Service".Length)
                : typeName;

            // Now 'typeWithoutService' will contain the part of the type name before "Service"
            string type = typeWithoutService;

            bool isOperationDone = false;

            while (!isOperationDone)
            {
                Console.WriteLine($"1.Add {type}.\n2.Update {type}.\n3.Delete {type}.\n4.Get {type} by Id.\n5.Get All {type}s.\n0.Exit {type} Menu");
                Console.Write("Enter operation number: ");
                int.TryParse(Console.ReadLine(), out int userChoice);


                switch (userChoice)
                {
                    case 1:
                        customerService.Add();
                        break;
                    case 2:
                        customerService.Update();
                        break;
                    case 3:
                        customerService.Delete();
                        break;
                    case 4:
                        customerService.GetById();
                        break;
                    case 5:
                        customerService.GetAll();
                        break;
                    case 0:
                        isOperationDone = true;
                        break;
                    default:
                        Console.WriteLine("Enter valid operation number");
                        break;

                }
            }

        }

        public void ShowMenu()
        {
            bool isOperationDone = false;

            while (!isOperationDone)
            {
                Console.WriteLine("Choose Menu.\n1. Customer Menu."); 
                
                Console.Write("Enter operation number: ");
                int.TryParse(Console.ReadLine(), out int userChoice);


                switch (userChoice)
                {
                    case 1:
                        CustomerService customerService = new CustomerService();
                        SubMenu(customerService);
                        break;
                    case 2:
                    
                        break;
                    case 3:
                     
                        break;
                    case 4:
                        
                        break;
                    case 5:
                      
                        break;
                    case 0:
                        isOperationDone = true;
                        break;
                    default:
                        Console.WriteLine("Enter valid operation number");
                        break;

                }
            }
        }
    }
}
