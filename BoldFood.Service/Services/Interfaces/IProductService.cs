﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Interfaces
{
    internal interface IProductService : IService
    {
        public void GetProductsByRestaurantId();
    }
}
