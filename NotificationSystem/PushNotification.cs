using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// In: /NotificationSystem/PushNotification.cs
namespace NotificationSystem;

public class PushNotification : Notification
{
    public PushNotification(string deviceId, string message)
        : base(deviceId, message) { }

    // Use the writer parameter
    public override void Send(TextWriter writer)
    {
        writer.WriteLine($"Push to {Recipient}: {Message}");
    }
}
