using Okyanus.EntityLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

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
