using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okyanus.EntityLayer.Entities;
using Okyanus.EntityLayer.Entities.identitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.DataAccessLayer.Config
{
    public class GroupConfig : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(e => new { e.ANAGRUP, e.ALTGRUP1, e.ALTGRUP2, e.ALTGRUP3 });
            //builder.HasIndex(e => new { e.ANAGRUP, e.ALTGRUP1, e.ALTGRUP2, e.ALTGRUP3 }).IsUnique();
            builder.HasIndex(e => e.GRUPADI).IsUnique();
        }
    }
}
