using Okyanus.EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.EntityLayer.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
