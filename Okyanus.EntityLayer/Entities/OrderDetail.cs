﻿using Okyanus.EntityLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Okyanus.EntityLayer.Entities
{
    public class OrderDetail : BaseEntity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Count { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }


        public string ProductID { get; set; }
        public Product Product { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
