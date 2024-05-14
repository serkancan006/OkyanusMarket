using Okyanus.EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.EntityLayer.Entities
{
    public class ProductType : BaseEntity
    {
        public string Birim { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal IncreaseAmount { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
