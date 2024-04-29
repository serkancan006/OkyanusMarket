using Okyanus.EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.EntityLayer.Entities
{
    public class District : BaseEntity
    {
        public string DistrictName { get; set; }
        public int CityID { get; set; }
        public City City { get; set; }
    }
}
