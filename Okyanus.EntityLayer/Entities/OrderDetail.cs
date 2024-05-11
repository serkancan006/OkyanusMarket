using Okyanus.EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.EntityLayer.Entities
{
    public class OrderDetail : BaseEntity
    {
        public decimal Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }


        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
