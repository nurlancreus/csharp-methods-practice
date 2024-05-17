using E_Commerce.Core.Models;
using E_Commerce.Data.Repositories.Implementations;
using E_Commerce.Data.Repositories.Interfaces;
using E_Commerce.Service.Helpers;
using E_Commerce.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository = new ProductRepository();

        private readonly IShopRepository shopRepository = new ShopRepository();
        private readonly IProductCategoryRepository productCategoryRepository = new ProductCategoryRepository();
        public void Add()
        {
            (string? name, string? description, int stock, double price, Shop? shop, ProductCategory? category) = GetFields(shopRepository, productCategoryRepository);

            if (name is not null && description is not null && shop is not null && category is not null)
            {
                Product product = new Product()
                {
                    Name = name,
                    Description = description,
                    Stock = stock,
                    Price = price,
                    Shop = shop,
                    Category = category,
                    CreatedAt = DateTime.Now
                };

                _repository.Add(product);
            }

        }

        public void Delete()
        {
            int id = (int)Utilities.ReadNumber("Enter the id of the product you'd like to delete");

            _repository.Delete(id);
        }

        public void GetAll()
        {
            foreach (Product product in _repository.GetAll())
            {
                Console.WriteLine(product);
            }
        }

        public void GetById()
        {
            int id = (int)Utilities.ReadNumber("Enter the id of the product you'd like to get");

            try
            {
                Product? product = _repository.GetById(id);

                if (product is not null)
                {
                    Console.WriteLine(product);
                }

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public void Update()
        {
            int id = (int)Utilities.ReadNumber("Enter the id of the product you'd like to update");

            try
            {
                Product? product = _repository.GetById(id);

                if (product is not null)
                {
                    (string? name, string? description, int stock, double price, Shop? shop, ProductCategory? category) = GetFields(shopRepository, productCategoryRepository);

                    if (name is not null && description is not null && shop is not null && category is not null)
                    {
                        product.Name = name;
                        product.Description = description;
                        product.Stock = stock;
                        product.Price = price;
                        product.Shop = shop;
                        product.Category = category;
                        product.UpdatedAt = DateTime.Now;

                        _repository.Update(product);
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        private static (string? name, string? description, int stock, double price, Shop? shop, ProductCategory? category) GetFields(IShopRepository shopRepo, IProductCategoryRepository productCategoryRepo)
        {
            try
            {
                // Prompt user for product details
                string name = Utilities.ReadString("Enter product name");
                string description = Utilities.ReadString("Enter product description");
                int stock = (int)Utilities.ReadNumber("Enter stocks count");
                double price = Utilities.ReadNumber("Enter product price");

                // Prompt user for shop and category IDs
                int shopId = (int)Utilities.ReadNumber("Enter shop Id");
                int categoryId = (int)Utilities.ReadNumber("Enter category Id");

                // Retrieve shop and category objects by their IDs
                Shop? shop = shopRepo.GetById(shopId);
                ProductCategory? category = productCategoryRepo.GetById(categoryId);

                // Validate if shop and category exist
                if (shop is null)
                {
                    Logger.ExceptionConsole("Shop not found.");
                }
                else if (category is null)
                {
                    Logger.ExceptionConsole("Category not found.");
                }
                else
                {
                    // Return the tuple with the provided details
                    return (name, description, stock, price, shop, category);
                }
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }

            // Return default values if an exception occurs or if shop/category is null
            return (null, null, 0, 0, null, null);
        }
    }
}