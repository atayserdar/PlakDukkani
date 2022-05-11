using PlakDukkani.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlakDukkani.DAL.Concrete.Context.EntityTypeConfiguration
{
    class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID)
                .UseIdentityColumn();

            builder.Property(a => a.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.AlbumArtUrl)
                .HasMaxLength(256);

            builder.Property(a => a.Price)
                .HasPrecision(8, 2);

            builder.Property(a => a.Discount)
                .HasPrecision(3, 2);


            builder.HasMany(a => a.OrderDetails)
              .WithOne(a => a.Album)
              .HasForeignKey(a => a.AlbumID);

            builder.HasOne(a => a.Genre)
                .WithMany(a => a.Albums)
                .HasForeignKey(a => a.GenreID);

            builder.HasOne(a => a.Artist)
                .WithMany(a => a.Albums)
                .HasForeignKey(a => a.ArtistID);               

        }
    }
}
