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
        public double TotalPrice { get; set; }
        public string? Description { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public string OrderFirstName { get; set; }
        public string OrderSurname { get; set; }
        public string OrderMail { get; set; }
        public string OrderPhone { get; set; }

        public string OrderAdress { get; set; }
        public string OrderApartman { get; set; }
        public string OrderDaire { get; set; }
        public string OrderKat { get; set; }
        public string OrderSehir { get; set; }
        public string OrderIlce { get; set; }
    }
}
