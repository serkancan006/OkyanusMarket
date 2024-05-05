using Okyanus.EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.EntityLayer.Entities
{
    public class TermsAndCondition : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
