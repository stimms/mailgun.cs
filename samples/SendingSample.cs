using System;
using System.Text;
using MailgunClient;

namespace MailgunSamples
{
    class SendingSample
    {
        public static void Main()
        {
            Mailgun.Init("key-afy6amxoo2fnj$u@mc");

            try
            {
                string sender = "me@samples.mailgun.org";
                string recipients = "You <you@samples.mailgun.org>, him@mailgun.info";
                string rawMime =
@"X-Priority: 1 (Highest)
Content-Type: text/plain;charset=UTF-8
From: me@samples.mailgun.org
To: you@mailgun.info
Subject: Hello!

This message is sent by Mailgun C# API";

                // Send a simpe text message
                MailgunMessage.SendText(sender, recipients,
                    "Hello!", "Hi!\nI am sending the message using Mailgun C# API");

                // Send a MIME message
                MailgunMessage.SendRaw(sender, recipients, Encoding.UTF8.GetBytes(rawMime));
				
                // .NET Framework also has System.Net.Mail.MailMessage class which simplifies
                // MIME constriction. MailMessage can be sent by System.Net.Mail.SmtpClient class.
                // Login into Mailgun Control Panel and look for your SMTP server address, user and password.

                Console.WriteLine("Messages sent");
            }
            catch (MailgunException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
