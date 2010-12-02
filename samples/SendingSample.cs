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
X-Mailgun-Tag: sample_raw
Content-Type: text/plain;charset=UTF-8
From: me@samples.mailgun.org
To: you@mailgun.info
Subject: Hello raw API!

This message is sent by Mailgun C# API";

                // Send a simpe text message
                MailgunMessage.SendText(sender, recipients,
                    "Hello text API!", "Hi!\nI am sending the message using Mailgun C# API");
   
                // Send a simpe text message and tag it
                var options = new MailgunMessage.Options();
                options.SetHeader(MailgunMessage.MAILGUN_TAG, "sample_text");
                MailgunMessage.SendText(sender, recipients,
                                        "Hello text API + tag!", "Hi!\nI am sending the message using Mailgun C# API and setting the tag",
                                        options);

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
