using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Okyanus.EntityLayer.Entities.Common;

namespace Okyanus.EntityLayer.Entities
{
    public class DeliveryTime : BaseEntity
    {
        public string? DeliveryTimeName { get; set; }
        public DateTime StartedTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
