﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Enums
{
    public enum OrderStatus
    {
        ProcessingStack = 1,
        ReadyForPacking,
        ReadyToDeliver,
        Delivered,
        Received,
        Refunded,
        NotDelivered
    }
}
