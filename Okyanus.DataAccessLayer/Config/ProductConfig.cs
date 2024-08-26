﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okyanus.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.DataAccessLayer.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(e => e.Group)
                .WithMany(e => e.Products)
                .HasForeignKey(e => new { e.ANAGRUP, e.ALTGRUP1, e.ALTGRUP2, e.ALTGRUP3 });
            //builder.HasIndex(e => e.AnaBarcode).IsUnique();

        }
    }
}
