using PlakDukkani.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlakDukkani.DAL.Concrete.Context.EntityTypeConfiguration
{
    class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID)
                .UseIdentityColumn();

            builder.Property(a => a.ShipAddress)
                .HasMaxLength(250);

            builder.HasOne(a => a.User)
               .WithMany(a => a.Orders)
               .HasForeignKey(a => a.UserID);
        }
    }
}
