using E_Commerce.Core.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Models
{
    public class OrderProduct : BaseEntity
    {

        public OrderProduct() : base("orderProduct")
        {

        }
        public int Count { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
