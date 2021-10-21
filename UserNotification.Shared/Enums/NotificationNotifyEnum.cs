using System.ComponentModel;

namespace UserNotification.Shared
{
    public enum NotificationNotifyEnum
    {
        [Description("No")]
        No = 0,
        Email = 1,
        Phone = 2,
        EmailAndPhone = 3
    }
}
