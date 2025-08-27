using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem;

public abstract class Notification
{
    public string Recipient { get; set; }
    public string Message { get; set; }

    protected Notification(string recipient, string message)
    {
        Recipient = recipient ?? throw new ArgumentNullException(nameof(recipient));
        Message = message ?? throw new ArgumentNullException(nameof(message));
    }
    public abstract void Send(TextWriter writer);
}
