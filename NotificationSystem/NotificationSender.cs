using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NotificationSystem;

public class NotificationSender
{
    public void SendNotification(Notification notification, TextWriter writer)
    {
        notification?.Send(writer);
    }

    public void SendMultiple(List<Notification> notifications, TextWriter writer)
    {
        notifications?.ForEach(notification => SendNotification(notification, writer));
    }
}
