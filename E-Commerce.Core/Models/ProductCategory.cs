using E_Commerce.Core.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Models
{
    public class ProductCategory : BaseEntity
    {

        public ProductCategory() : base("productCategory")
        {

        }
        public string Name { get; set; } = String.Empty;

        public override string ToString()
        {
            return $"Id: {Id} - Category: {Name} - Created: {CreatedAt}";
        }
    }
}
