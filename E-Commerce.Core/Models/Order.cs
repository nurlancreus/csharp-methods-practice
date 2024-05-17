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
        Customer customer {  get; set; }
        OrderStatus status { get; set; }

    }
}
