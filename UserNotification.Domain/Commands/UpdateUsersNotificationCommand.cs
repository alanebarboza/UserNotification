
using System;
using UserNotification.Shared;
using UserNotification.Shared.Entities;
using UserNotification.Shared.Interfaces;

namespace UserNotification.Domain.Commands
{
    public sealed class UpdateUsersNotificationCommand : ICommand
    {
        public UpdateUsersNotificationCommand(int id, NotificationTypeEnum type, string description, decimal value, string barCode, DateTime? paymentDate, DateTime? paidDate, string paidBy, NotificationNotifyEnum notify)
        {
            Id = id;
            Type = type;
            Description = description;
            Value = value;
            BarCode = barCode;
            PaymentDate = paymentDate;
            PaidDate = paidDate;
            PaidBy = paidBy;
            Notify = notify;
        }

        public int Id { get; private set; }
        public NotificationTypeEnum Type { get; private set; }
        public string Description { get; private set; }
        public decimal Value { get; private set; }
        public string BarCode { get; private set; }
        public Nullable<DateTime> PaymentDate { get; private set; }
        public Nullable<DateTime> PaidDate { get; private set; }
        public string PaidBy { get; private set; }
        public NotificationNotifyEnum Notify { get; private set; }
    }
}
