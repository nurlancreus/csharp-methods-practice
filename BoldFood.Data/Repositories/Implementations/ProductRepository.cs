using BoltFood.Core.Models;
using BoltFood.Data.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Data.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>
    {
       //private static List<Product> _products = new List<Product>();
       // public void Add(Product product)
       // {
       //     _products.Add(product);
       // }

       // public void Delete(int id)
       // {
       //     Product product = GetById(id);
       //     _products.Remove(product);
       // }

       // public List<Product> GetAll()
       // {
       //     return _products;
       // }

       // public Product GetById(int id)
       // {
       //     Product product = _products.FirstOrDefault(p => p.Id == id);
       //     return product == null ? throw new Exception("Product not found") : product;
       // }

       // public void Update(int id, Product product)
       // {
       //     Product foundProduct = GetById(id);
       //     if (foundProduct != null)
       //     {
       //         foundProduct.Price = product.Price;
       //         foundProduct.Description = product.Description;
       //         foundProduct.Name = product.Name;
       //         foundProduct.Restaurant = product.Restaurant;
       //         foundProduct.Category = product.Category;
       //     }
       // }
    }
}
