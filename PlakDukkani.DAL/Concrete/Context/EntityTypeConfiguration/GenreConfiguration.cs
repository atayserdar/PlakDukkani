using PlakDukkani.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlakDukkani.DAL.Concrete.Context.EntityTypeConfiguration
{
    class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(a => a.ID);

            builder.Property(a => a.ID).UseIdentityColumn();

            builder.Property(a => a.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Description)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
