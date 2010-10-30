using System;
using System.Collections.Generic;
using MailgunClient;
using System.Text;

namespace MailgunSamples
{
    public class MailboxSample
    {

        public static void Main ()
        {
            Mailgun.Init("key-afy6amxoo2fnj$u@mc");

            Mailbox mailbox = new Mailbox ("new1", "samples.mailgun.org", "123123");
            try {
                // Create new mailbox
                mailbox.Upsert ();
                
                // Update it
                mailbox.Password = "123456";
                mailbox.Upsert ();
                
                // Upsert from CSV
                Mailbox.UpsertFromCsv (Encoding.UTF8.GetBytes ("up1@samples.mailgun.org, abc123\nup2@samples.mailgun.org, 321bca"));
                
                //Now enjoy the scene:
                List<Mailbox> list = Mailbox.Find ();
                Console.WriteLine ("Mailboxes:\n");
                foreach (Mailbox m in list)
                    Console.WriteLine ("{0}@{1} {2}", m.User, m.Domain, m.Size);
            } catch (MailgunException ex) {
                Console.WriteLine (ex.StackTrace);
                Console.WriteLine (ex.Message);
            }
        }
    }
}
