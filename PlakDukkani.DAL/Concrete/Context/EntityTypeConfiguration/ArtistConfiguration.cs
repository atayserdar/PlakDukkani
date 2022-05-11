using PlakDukkani.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlakDukkani.DAL.Concrete.Context.EntityTypeConfiguration
{
    class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(a => a.ID);

            builder.Property(a => a.ID).UseIdentityColumn();

            builder.Property(a => a.FullName)
                .HasMaxLength(100).IsRequired();

            builder.Property(a => a.Bio)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
