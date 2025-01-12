using System;
using System.Net;
using System.Net.Mail;

public static class Email{
    public static void SendEmail(Configuration config, string body, string subject){
        try{
            var client = new SmtpClient(config.smtpServer, config.smtpPort);
            client.Credentials = new NetworkCredential(config.smtpUser, config.smtpPassword);
            client.EnableSsl = true;
    
            var mail = new MailMessage();
            mail.From = new MailAddress(config.smtpUser);
            mail.To.Add(config.emailDestination);
            mail.Subject = subject;
            mail.Body = body;

            client.Send(mail);

            Console.WriteLine($"Email enviado: {subject}");
        }
        catch (Exception ex){
            Console.WriteLine("Erro ao enviar o Email!");
        }
    }
}