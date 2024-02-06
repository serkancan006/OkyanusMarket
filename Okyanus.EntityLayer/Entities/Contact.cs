using Okyanus.EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.EntityLayer.Entities
{
    public class Contact : BaseEntity
    {
        public string Title { get; set; }
        public string Adres { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string MapLocation { get; set; }
    }
}
