using PlakDukkani.Model.Entities;
using PlakDukkani.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlakDukkani.DAL.Concrete.Context.EntityTypeConfiguration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
      
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID)
                .UseIdentityColumn();

            builder.Property(a => a.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Password)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(a => a.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.PhoneNumber)
                .HasMaxLength(18);

            builder.Property(a => a.Address)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(a => a.Email)
                .IsUnique();

            builder.HasData(new User
            {
                ID = 1,
                FirstName = "Gizem",
                LastName = "İşeri",
                Email = "gizem.iseri@bilgeadam.com",
                Password = "123",
                Address = "Bilgeadam",
                Role = UserRole.Admin,
                IsActive = true
            });
        }
    }
}
