using E_Commerce.Core.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Models
{
    public class Product : BaseEntity
    {

        public Product() : base("product")
        {

        }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Stock { get; set; } = 0;
        public double Price { get; set; } = 0;
        public Shop? Shop { get; set; } = null;
        public ProductCategory? Category { get; set; } = null;

        public override string ToString()
        {
            return $"Id: {Id} - Name: {Name} - Description: {Description} - Stocks: {Stock} - Price: {Price} - Shop: {Shop?.Name} - Category: {Category?.Name} - Created: {CreatedAt}";
        }
    }
}
