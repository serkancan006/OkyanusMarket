using Okyanus.EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.EntityLayer.Entities
{
    public class ProductType : BaseEntity
    {
        public string Birim { get; set; }
        public double IncreaseAmount { get; set; }

        public List<Product> Products { get; set; }
    }
}
