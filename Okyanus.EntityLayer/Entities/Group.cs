using Okyanus.EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.EntityLayer.Entities
{
    public class Group
    {
        public string ANAGRUP { get; set; }
        public string ALTGRUP1 { get; set; } 
        public string ALTGRUP2 { get; set; } 
        public string ALTGRUP3 { get; set; } 
        public string GRUPADI { get; set; }
        public string? Description { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
