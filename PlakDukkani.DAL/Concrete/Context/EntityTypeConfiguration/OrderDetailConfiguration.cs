using PlakDukkani.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlakDukkani.DAL.Concrete.Context.EntityTypeConfiguration
{
    class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(a => new { a.AlbumID, a.OrderID });

            builder.Ignore(a => a.TotalPrice);
        }
    }
}
