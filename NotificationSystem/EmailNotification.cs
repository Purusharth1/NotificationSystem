using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem;
public class EmailNotification : Notification
{
    public string Subject { get; set; }
    public EmailNotification(string recipient, string message, string subject)
        : base(recipient, message)
    {
        Subject = subject ?? throw new ArgumentNullException(nameof(subject));
    }
    public override void Send(TextWriter writer)
    {
        writer.WriteLine($"Email to {Recipient}: {Subject} - {Message}");
    }
}
