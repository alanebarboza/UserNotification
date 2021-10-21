using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserNotification.Domain.Entities;

namespace UserNotification.Infra.EntityTypeConfiguration
{
    class UsersNotificationEntityTypeConfiguration : IEntityTypeConfiguration<UsersNotifications>
    {
        public void Configure(EntityTypeBuilder<UsersNotifications> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasOne("Users").WithMany("UsersNotifications").IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.BarCode).HasMaxLength(60);
            builder.Property(x => x.Value).HasPrecision(24, 9);
            builder.Property(x => x.PaymentDate).IsRequired();
            builder.Property(x => x.PaidDate);
            builder.Property(x => x.PaidBy).HasMaxLength(50);
            builder.Property(x => x.Notify);
        }
    }
}
