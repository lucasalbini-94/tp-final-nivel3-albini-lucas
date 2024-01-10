using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Servicios
{
    public class EmailServicios
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailServicios()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("lucasprogramacion1@gmail.com", "ctlbtbndtipbkiyp");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }
        public void armarCorreo(string direccion, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("tiendaonline@gmail.com");
            email.To.Add(direccion);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = cuerpo;
        }
        public void enviarCorreo()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
