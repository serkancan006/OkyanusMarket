using Okyanus.EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.EntityLayer.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
