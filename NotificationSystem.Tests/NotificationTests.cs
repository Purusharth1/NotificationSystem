// In: /NotificationSystem.Tests/NotificationTests.cs
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NotificationSystem.Tests;
[TestClass]
public class NotificationTests
{
    [TestMethod]
    public void EmailNotification_Send_WritesCorrectFormatToWriter()
    {
        // Arrange
        var email = new EmailNotification("test@example.com", "Test message", "Test Subject");
        using var writer = new StringWriter(); // Use a local StringWriter
        string expectedOutput = "Email to test@example.com: Test Subject - Test message" + writer.NewLine;

        // Act
        email.Send(writer); // Pass the writer directly

        // Assert
        Assert.AreEqual(expectedOutput, writer.ToString());
    }

    [TestMethod]
    public void SmsNotification_Send_WritesToWriter()
    {
        // Arrange
        var sms = new SmsNotification("1234567890", "SMS test message");
        using var writer = new StringWriter();
        string expectedOutput = "SMS to 1234567890: SMS test message" + writer.NewLine;

        // Act
        sms.Send(writer);

        // Assert
        Assert.AreEqual(expectedOutput, writer.ToString());
    }

    [TestMethod]
    public void NotificationSender_Polymorphism_SendsDifferentTypes()
    {
        // Arrange
        var sender = new NotificationSender();
        var notifications = new List<Notification>
        {
            new EmailNotification("test@example.com", "Email msg", "Subject"),
            new SmsNotification("123456", "SMS msg"),
            new PushNotification("device1", "Push msg")
        };
        using var writer = new StringWriter();

        // Act
        sender.SendMultiple(notifications, writer); // Pass the writer to the sender

        // Assert
        string result = writer.ToString();
        StringAssert.Contains(result, "Email to test@example.com");
        StringAssert.Contains(result, "SMS to 123456");
        StringAssert.Contains(result, "Push to device1");
    }
    [TestMethod]
    public void Notification_Constructor_NullMessage_ThrowsArgumentNullException()
    {
        // This test verifies that the base class constructor correctly rejects a null message.
        // We use a concrete class like SmsNotification to test the abstract class's logic.
        Assert.ThrowsException<ArgumentNullException>(
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            () => new SmsNotification("123456", null)
#pragma warning restore CS8625
        );
    }

    [TestMethod]
    public void EmailNotification_Constructor_NullSubject_ThrowsArgumentNullException()
    {
        // This test is specific to EmailNotification, ensuring its extra property is also validated.
        Assert.ThrowsException<ArgumentNullException>(
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            () => new EmailNotification("test@test.com", "message", null)
#pragma warning restore CS8625
        );
    }

    [TestMethod]
    public void NotificationSender_SendMultiple_WithEmptyList_ProducesNoOutput()
    {
        // This tests the boundary condition of an empty list.
        var sender = new NotificationSender();
        var notifications = new List<Notification>();
        using var writer = new StringWriter();

        // Act
        sender.SendMultiple(notifications, writer);

        // The output should be an empty string.
        Assert.AreEqual("", writer.ToString());
    }
}
