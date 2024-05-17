using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Models.BaseModel
{
    public class BaseEntity
    {
        private static int _customerCount = 0;
        private static int _orderCount = 0;
        private static int _orderProductCount = 0;
        private static int _productCount = 0;
        private static int _productCategoryCount = 0;
        private static int _shopCount = 0;
        //private static int _count = 0;
        public readonly int Id;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public BaseEntity(string entity)
        {
            //Id = ++_count;

            if (entity == "customer") Id = ++_customerCount;
            if (entity == "order") Id = ++_orderCount;
            if (entity == "orderProduct") Id += ++_orderProductCount;
            if (entity == "product") Id += ++_productCount;
            if (entity == "productCategory") Id += ++_productCategoryCount;
            if (entity == "shop") Id += ++_shopCount;
        }
    }
}
