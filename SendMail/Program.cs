using System;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace TestClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Sender Name", "jipatel052003@gmail.com"));
            email.To.Add(new MailboxAddress("Receiver Name", "jaypatel052003@gmail.com"));

            email.Subject = "Testing out email sending";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "<b>Hello all the way from the land of C#</b>"
            };
            var builder = new BodyBuilder();

            // Set the plain-text version of the message text
            builder.TextBody = @"Hey,
                Just wanted to say hi all the way from the land of C#. Also, here's a cool PDF tutorial for you!
                -- Code guy
                ";

            // The part where we include the new attachment...
            builder.Attachments.Add(@"C:\Users\jaypa\OneDrive\Desktop\JayPatelresume.pdf");
            builder.Attachments.Add(@"C:\Users\jaypa\OneDrive\Desktop\JayPatelresume.pdf");
            builder.Attachments.Add(@"C:\Users\jaypa\OneDrive\Desktop\JayPatelresume.pdf");

            email.Body = builder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate("jipatel052003@gmail.com", "ppzfamsgkqqzgfdv");

                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
}