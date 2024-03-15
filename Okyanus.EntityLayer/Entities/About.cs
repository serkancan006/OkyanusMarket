using Okyanus.EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.EntityLayer.Entities
{
    public class About : BaseEntity
    { 
        public string AboutDesc { get; set; }
        public string Misyon { get; set; }
        public string Vizyon { get; set; }
    }
}
