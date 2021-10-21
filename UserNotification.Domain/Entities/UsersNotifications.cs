using System;
using UserNotification.Shared;
using UserNotification.Shared.Entities;

namespace UserNotification.Domain.Entities
{
    public sealed class UsersNotifications : BaseEntity
    {
        public UsersNotifications(int id, NotificationTypeEnum type, string description, decimal value, string barCode, DateTime? paymentDate, DateTime? paidDate, string paidBy, NotificationNotifyEnum notify) : base(id)
        {
            Type = type;
            Description = description;
            Value = value;
            BarCode = barCode;
            PaymentDate = paymentDate;
            PaidDate = paidDate;
            PaidBy = paidBy;
            Notify = notify;
        }
        public NotificationTypeEnum Type { get; private set; }
        public string Description { get; private set; }
        public decimal Value { get; private set; }
        public string BarCode { get; private set; }
        public Nullable<DateTime> PaymentDate { get; private set; }
        public Nullable<DateTime> PaidDate { get; private set; }
        public string PaidBy { get; private set; }
        public NotificationNotifyEnum Notify { get; private set; }
        private Users Users { get; set; }

    }
}
