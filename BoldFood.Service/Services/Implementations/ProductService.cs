using BoltFood.Core.Enums;
using BoltFood.Core.Models;
using BoltFood.CoreModels;
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
    public class ProductService : IProductService
    {
        private readonly ProductRepository _repository = new ProductRepository();
        private readonly RestaurantRepository _restaurantRepository = new RestaurantRepository();

        //public void Add()
        //{
        //    try
        //    {
        //        Console.WriteLine("Enter the product name.");
        //        string name = Console.ReadLine();

        //        Console.Write("Price: ");
        //        double price = Convert.ToDouble(Console.ReadLine());

        //        Console.Write("Description: ");
        //        string description = Console.ReadLine();

        //        var productCategories = Enum.GetValues(typeof(ProductCategory));
        //        foreach (var category in productCategories)
        //        {
        //            Console.WriteLine((int)category + ". " + category);
        //        }

        //        Console.Write("Category Number: ");
        //        int categoryNum = Convert.ToInt32(Console.ReadLine());
        //        string categoryName = Enum.GetName(typeof(ProductCategory), categoryNum);    

        //        Product product = new Product() { Name = name, Price = price, Description = description, Category = Enum.TryParse(typeof(ProductCategory), categoryName), CreatedAt = DateTime.Now };

        //        _repository.Add(product);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //}


        public void Add()
        {
            try
            {
                //Product product = Utilities.CreateProduct(_restaurantRepository);

                (string name, double price, string description, ProductCategory category, Restaurant restaurant) = Utilities.CreateProduct(_restaurantRepository);
                Product product = new Product() { Name = name, Price = price, Description = description, Category = category, Restaurant = restaurant };

                // Add the product to the repository
                _repository.Add(product);

                restaurant.Products.Add(product);

                Console.WriteLine("Product added successfully!");

            }

            catch (Exception ex)
            {
                Utilities.ExceptionConsole($"An error occurred: {ex.Message}");
            }
        }

        //public void Add()
        //{
        //    try
        //    {
        //        Console.WriteLine("Enter the product name:");
        //        string name = Console.ReadLine().Trim(); // Read and trim input

        //        double price;
        //        while (!double.TryParse(Console.ReadLine(), out price))
        //        {
        //            Console.WriteLine("Invalid price format. Please enter a valid number:");
        //        }

        //        Console.WriteLine("Enter the description:");
        //        string description = Console.ReadLine().Trim();

        //        // Display available product categories
        //        Console.WriteLine("Product Categories:");
        //        foreach (ProductCategory category in Enum.GetValues(typeof(ProductCategory)))
        //        {
        //            Console.WriteLine($"{(int)category}. {category}");
        //        }

        //        Console.Write("Enter the category number: ");
        //        if (int.TryParse(Console.ReadLine(), out int categoryNum) && Enum.IsDefined(typeof(ProductCategory), categoryNum))
        //        {
        //            ProductCategory selectedCategory = (ProductCategory)categoryNum;

        //            // Create the Product object with the user input
        //            Product product = new Product
        //            {
        //                Name = name,
        //                Price = price,
        //                Description = description,
        //                Category = selectedCategory,
        //                CreatedAt = DateTime.Now
        //            };

        //            // Add the product to the repository
        //            _repository.Add(product);

        //            Console.WriteLine("Product added successfully!");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid category number. Please select a valid category.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //    }
        //}
        public void Delete()
        {
            try
            {
                //int id = Convert.ToInt32(Console.ReadLine());
                int id = ((int)((double)0).ReadNumber("Enter the id of product you wanted to remove: "));

                _repository.Delete(id);
            }
            catch (Exception ex)
            {
                Utilities.ExceptionConsole($"An error occurred: {ex.Message}");
            }
        }

        public void GetAll()
        {
            Console.WriteLine("All products: ");
            foreach (Product product in _repository.GetAll())
            {
                Console.WriteLine(product.ToString());
            }
        }

        public void GetById()
        {
            try
            {
                //int id = Convert.ToInt32(Console.ReadLine());
                int id = (int)((double)0).ReadNumber("Enter the id of product you wanted to get: ");
                _repository.GetById(id);

            }
            catch (Exception ex)
            {
                Utilities.ExceptionConsole($"An error occurred: {ex.Message}");
            }
        }

        public void GetProductsByRestaurantId()
        {
            try
            {

                int id = (int)((double)0).ReadNumber("Enter the id of restaurant you wanted to get products: ");

                if (_restaurantRepository.GetById(id) != null)
                {
                    var productsByRestaurantId = _repository.GetAll().Where(p => p.Restaurant.Id == id);

                    foreach (var product in productsByRestaurantId)
                    {
                        Console.WriteLine(product.ToString());
                    }
                }
                throw new Exception("There is no such restaurant");
            }
            catch (Exception ex)
            {
                Utilities.ExceptionConsole($"An error occurred: {ex.Message}");
            }
        }

        public void Update()
        {
            int id = (int)((double)0).ReadNumber("Enter the id of product you wanted to update: ");
            Product updatedProduct = _repository.GetById(id);
            if (updatedProduct != null)
            {
                //Product product = Utilities.CreateProduct(_restaurantRepository);

                (string name, double price, string description, ProductCategory category, Restaurant restaurant) = Utilities.CreateProduct(_restaurantRepository);
                //Product product = new Product() { Name = name, Price = price, Description = description, Category = category, Restaurant = restaurant };

                Restaurant oldRestaurant = updatedProduct.Restaurant;

                updatedProduct.Name = name;
                updatedProduct.Price = price;
                updatedProduct.Description = description;
                updatedProduct.Category = category;
                updatedProduct.Restaurant = restaurant;

                // Update the product in the repository

                _repository.Update(id, updatedProduct);

                if (oldRestaurant != restaurant)
                {
                    oldRestaurant.Products.Remove(updatedProduct);
                    restaurant.Products.Add(updatedProduct);
                }

            };

        }
    }
}
