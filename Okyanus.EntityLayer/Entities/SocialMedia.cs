using Okyanus.EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.EntityLayer.Entities
{
    public class SocialMedia : BaseEntity
    {
        public string MediaName { get; set; }
        public string MediaUrl { get; set; }
    }
}
