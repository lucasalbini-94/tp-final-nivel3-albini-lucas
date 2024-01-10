using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Servicios;

namespace Ventanas
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            // Revisar validaciones
            Page.Validate();
            if (!Page.IsValid)
                return;

            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                EmailServicios email = new EmailServicios();
                Usuario nuevo = new Usuario();
                nuevo.Email = tbxEmail.Text;
                nuevo.Pass = tbxPass.Text;
                nuevo.Admin = false;
                negocio.agregarUsuario(nuevo);
                Session.Add("user", nuevo);
                string asunto = "Bienvenido a nuestra tienda online";
                string mensaje = "<h1>Bienvenido a la Tienda Online</h1> <br><p>Estimado " + nuevo.Email + ",</p>" +
                "<p>¡Gracias por registrarte en nuestra tienda online de electrodomésticos y artículos de electrónica y computación! Estamos emocionados de tenerte como parte de nuestra comunidad.</p>" +
                "<p> Para comenzar a explorar nuestra amplia gama de productos, te invitamos a visitar nuestra tienda oficial. ¡Descubre las últimas novedades y ofertas exclusivas! </p>" +
                "<p>Esperamos que encuentres todo lo que necesitas.Si tienes alguna pregunta o necesitas asistencia, no dudes en ponerte en contacto con nuestro equipo de soporte.</p>" +
                "<p>Gracias nuevamente por elegirnos.</p>" +
                "<p>Atentamente,<br>El Equipo de la Tienda Online</p>";
                email.armarCorreo(nuevo.Email, asunto, mensaje);
                email.enviarCorreo();
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx?code=00", false);
            }
        }
    }
}