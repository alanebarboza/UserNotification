using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserNotification.Domain.Entities;

namespace UserNotification.Infra.EntityTypeConfiguration
{
    class UsersEntityTypeConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(c => c.Nick).HasMaxLength(20).IsRequired();
            builder.Property(c => c.PassWord).HasMaxLength(20).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(80).IsRequired();
            builder.Property(c => c.Phone).HasMaxLength(15);
            builder.Property(c => c.Email).HasMaxLength(50);
            builder.HasMany("UsersNotifications").WithOne("Users");
        }
    }
}
