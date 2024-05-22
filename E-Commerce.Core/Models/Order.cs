using E_Commerce.Core.Enums;
using E_Commerce.Core.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Models
{
    public class Order : BaseEntity
    {
        public Order() : base("order")
        {

        }
        public Customer Customer { get; set; }
        public OrderStatus Status { get; set; }

        public List<OrderProduct> OrderProducts  = new List<OrderProduct>();

    }
}
