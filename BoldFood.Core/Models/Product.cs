using BoltFood.Core.Enums;
using BoltFood.Core.Models.BaseModel;
using BoltFood.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Core.Models
{
    public class Product : BaseEntity
    {
        public Product() : base("product")
        {
        }

        public double Price { get; set; }
        public string Description { get; set; }
        public ProductCategory Category { get; set; }
        public Restaurant Restaurant { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Name: {Name} - Desc: {Description} - Price: {Price} - Category: {Category} - Restaurant: {Restaurant.Name}";
        }
    }
}
