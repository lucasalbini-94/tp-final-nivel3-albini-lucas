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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            // Revisar validaciónes
            Page.Validate();
            if (!Page.IsValid)
                return;

            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                string mail = tbxEmail.Text;
                string pass = tbxPass.Text;
                Usuario logueado = negocio.buscar(mail, pass);
                
                if(logueado != null)
                {
                    logueado.Email = tbxEmail.Text;
                    logueado.Pass = tbxPass.Text;
                    Session.Add("user", logueado);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario o contraseña incorrectos. Por favor, vuelva a intentarlo.");
                    Response.Redirect("Error.aspx?code=01", false);
                }
                

            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx?code=00", false);
            }
        }
    }
}