using Okyanus.EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.EntityLayer.Entities
{
    public class MyPhone : BaseEntity
    {
        public string PhoneName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
