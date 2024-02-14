using Okyanus.EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.EntityLayer.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double? DiscountedPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public Birim ProductType { get; set; }  // 0 => kg -- 1 => Adet
        public List<Category> Categories { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Basket> Baskets { get; set; }
    }

    public enum Birim
    {
        Kg,
        Adet
    }
}
