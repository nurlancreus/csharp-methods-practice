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
    public class ShopService : IShopService
    {
        private readonly IShopRepository _repository = new ShopRepository();
        public void Add()
        {
            (string? name, string? description, float rating) = GetFields();

            if (name is not null && description is not null)
            {
                Shop shop = new Shop()
                {
                    Name = name,
                    Description = description,
                    Rating = rating,
                    CreatedAt = DateTime.Now
                };

                _repository.Add(shop);
            }
        }

        public void Delete()
        {
            int id = (int)Utilities.ReadNumber("Enter the id of the shop you'd like to delete");
            try
            {
                _repository.Delete(id);
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }

        }

        public void GetAll()
        {
            foreach (Shop shop in _repository.GetAll())
            {
                Console.WriteLine(shop);
            }
        }

        public void GetById()
        {
            int id = (int)Utilities.ReadNumber("Enter the id of the shop you'd like to get");
            try
            {
                Shop? shop = _repository.GetById(id);

                if (shop is not null) Console.WriteLine(shop);
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public void Update()
        {
            int id = (int)Utilities.ReadNumber("Enter the id of the shop you'd like to update");

            try
            {
                Shop? shop = _repository.GetById(id);

                (string? name, string? description, float rating) = GetFields();


                if (shop is not null && name is not null && description is not null)
                {
                    shop.Name = name;
                    shop.Description = description;
                    shop.Rating = rating;
                    shop.UpdatedAt = DateTime.Now;

                    _repository.Update(shop);
                }

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }

        }
        private static (string? name, string? description, float rating) GetFields()
        {
            try
            {
                // Prompt user for details
                string name = Utilities.ReadString("Enter name");
                string description = Utilities.ReadString("Enter description");
                float rating = (float)Utilities.ReadNumber("Enter rating");

                // Return the tuple with the provided details
                return (name, description, rating);
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }

            // Return default values if an exception occurs
            return (null, null, 0);
        }
    }
}
