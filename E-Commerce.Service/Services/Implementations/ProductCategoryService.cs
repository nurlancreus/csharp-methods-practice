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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _repository = new ProductCategoryRepository();
        public void Add()
        {
            string name = Utilities.ReadString("Enter the category name");

            ProductCategory category = new ProductCategory() { Name = name, CreatedAt = DateTime.Now };

            _repository.Add(category);
        }

        public void Delete()
        {
            int id = (int)Utilities.ReadNumber("Enter the id of the category you'd like to delete");

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
            foreach (ProductCategory category in _repository.GetAll())
            {
                Console.WriteLine(category);
            }
        }

        public void GetById()
        {
            int id = (int)Utilities.ReadNumber("Enter the id of the category you'd like to get");

            ProductCategory? category = _repository.GetById(id);

            if (category is not null) Console.WriteLine(category);
        }

        public void Update()
        {
            int id = (int)Utilities.ReadNumber("Enter the id of the category you'd like to update");

            try
            {
                ProductCategory? category = _repository.GetById(id);

                if (category is not null)
                {
                    string name = Utilities.ReadString("Enter new name: ");

                    category.Name = name;
                    category.UpdatedAt = DateTime.Now;

                    _repository.Update(category);
                }
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }
    }
}
