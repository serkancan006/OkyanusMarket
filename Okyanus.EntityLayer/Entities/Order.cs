﻿using Okyanus.EntityLayer.Entities.Common;
using Okyanus.EntityLayer.Entities.identitiy;
using System.ComponentModel.DataAnnotations.Schema;

namespace Okyanus.EntityLayer.Entities
{
    public class Order : BaseEntity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public string? Description { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public string OrderStatus { get; set; }

        public string TeslimatYontemi { get; set; }
        public string TeslimatSaati { get; set; }
        public string AlternatifUrun { get; set; }

        public string OrderFirstName { get; set; }
        public string OrderSurname { get; set; }
        public string OrderMail { get; set; }
        public string OrderPhone { get; set; }
        //public string OrderUserPhone { get; set; }

        public string OrderAdress { get; set; }
        public string OrderApartman { get; set; }
        public string OrderDaire { get; set; }
        public string OrderKat { get; set; }
        public string OrderSehir { get; set; }
        public string OrderIlce { get; set; }

        public string OrderPaymentType { get; set; }

        public int? AppUserID { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
