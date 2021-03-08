using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Domain.Interfaces.IServices;

namespace Services.Services
{
    public class EmailService : IEmailService
    {
        public EmailService()
        {
            
        }

        public async Task<bool> EnviarEmail(string descricaoalarme, string nomeEquipamento)
        {
            return await GerarEmail(descricaoalarme, nomeEquipamento);
        }

        private async Task<bool> GerarEmail(string descricaoalarme, string nomeEquipamento)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("treetech.treino@gmail.com");
                mail.To.Add("treetech.treino@gmail.com");
                mail.Subject = "Alarme de classificação 'Alto' ativado";
                mail.Body = GerarCorpoEmail(descricaoalarme, nomeEquipamento);
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("treetech.treino@gmail.com", "treetech123");
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }

                return true;
            }
        }

        private string GerarCorpoEmail(string descricao, string nomeEquipamento)
        {
            return "<h1>Notificação</h1>" +
                   $"Informamos que o Equipamento: {nomeEquipamento} teve o Alarme com a descrição de {descricao} foi ativado às {DateTime.Now:t} do dia {DateTime.Now:d} " +
                   "<p></p>" +
                   "<p></p>" +
                   "Atenciosamente," +
                   "<p></p>" +
                   "<p></p>" +
                   "Equipe Treetech";
        }
    }
}