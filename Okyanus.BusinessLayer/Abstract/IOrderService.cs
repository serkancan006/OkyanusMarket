﻿using Okyanus.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        Task UpdateOrderStatusAsync(int id, string orderStatus);
    }
}
