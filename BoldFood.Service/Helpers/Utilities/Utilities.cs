using BoltFood.Core.Enums;
using BoltFood.Core.Models;
using BoltFood.CoreModels;
using BoltFood.Data.Repositories.Implementations;
using BoltFood.Service.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Helpers.Utilities
{
    public class Utilities
    {
        public static void ExceptionConsole(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\n{message}\n");
            Console.ResetColor();
        }

        public static (string name, double price, string description, ProductCategory category, Restaurant restaurant) CreateProduct(RestaurantRepository restaurantRepo)
        {
            string name = "".ReadString("Enter the product name: ");

            //double price = Convert.ToDouble(Console.ReadLine());
            double price = ((double)0).ReadNumber("Enter the price: ", "Invalid price format. Please enter a valid number.");

            string description = "".ReadString("Enter the description: ");

            // Display available product categories
            Console.WriteLine("Product Categories:");
            foreach (ProductCategory category in Enum.GetValues(typeof(ProductCategory)))
            {
                Console.WriteLine($"{(int)category}. {category}");
            }

            ProductCategory selectedCategory;

            while (true)
            {
                if (int.TryParse(((double)0).ReadNumber("Enter the category number: ").ToString(), out int categoryNum) && Enum.IsDefined(typeof(ProductCategory), categoryNum))
                {
                    selectedCategory = (ProductCategory)categoryNum;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid category number. Please select a valid one.");
                }
            }


            int restaurantId = (int)((double)0).ReadNumber("Enter the restaurant id: ");
            Restaurant restaurant = restaurantRepo.GetById(restaurantId);

            // Create the Product object with the user input
            //Product product = new Product
            //{
            //    Name = name,
            //    Price = price,
            //    Description = description,
            //    Category = selectedCategory,
            //    Restaurant = restaurant
            //};

            //restaurant.Products.Add(product);


            //return product;

            return
            (
                name,
                price,
                description,
                category: selectedCategory,
                restaurant
            );
        }
    }
}
