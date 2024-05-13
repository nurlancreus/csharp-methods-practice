using BoltFood.Core.Models;
using BoltFood.Core.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.CoreModels
{
    public class Restaurant : BaseEntity
    {

        public string Address { get; set; }
        public string Phone { get; set; }
        public List<Product> Products { get; set; }

        public Restaurant()
        {
            Products = new List<Product>();
        }
        public override string ToString()
        {
            string productsStr = Products.Any() ? string.Join(", ", Products) : "None";

            return $"id: {Id}, Name: {Name}, Address: {Address}, Phone: {Phone}, Products: {productsStr}";
        }
    }
}
