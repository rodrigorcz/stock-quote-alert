using System;
using System.Net;
using System.Net.Mail;

public static class Email{
    public static void SendEmail(Configuration config, string subject, string body){
        try{

            // configura o cliente SMTP
            var client = new SmtpClient(config.smtpServer, config.smtpPort);
            client.Credentials = new NetworkCredential(config.smtpUser, config.smtpPassword);
            client.EnableSsl = true;
    
            // instancia o Email com as informações necessarias
            var mail = new MailMessage();
            mail.From = new MailAddress(config.smtpUser);
            mail.To.Add(config.emailDestination);
            mail.Subject = subject;
            mail.Body = body;

            // envia o email
            client.Send(mail);
            Console.WriteLine($"Email enviado: {subject}");
        }
        catch(Exception){
            Console.WriteLine("Erro ao enviar o Email!");
        }
    }
}