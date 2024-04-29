using Okyanus.EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.EntityLayer.Entities
{
    public class City : BaseEntity
    {
        public string CityName { get; set; }
        public List<District> Districts { get; set; }
    }
}
