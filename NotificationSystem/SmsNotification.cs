using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// In: /NotificationSystem/SmsNotification.cs
namespace NotificationSystem;

public class SmsNotification : Notification
{
    public SmsNotification(string phoneNumber, string message)
        : base(phoneNumber, message) { }

    // Use the writer parameter
    public override void Send(TextWriter writer)
    {
        writer.WriteLine($"SMS to {Recipient}: {Message}");
    }
}
