using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ventanas
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Generar el mensaje de error en la pantalla
            lblError.Text = Session["error"].ToString();

            // Definir las opciones según el codigo de error recibido por URL
            if (Request.QueryString["code"] != null)
            {
                int code = int.Parse(Request.QueryString["code"].ToString());

                // code 00 = Error genérico
                if (code == 00)
                {
                    hlkRedirect1.Visible = true;
                    hlkRedirect1.Text = "Vuelva al inicio ";
                    hlkRedirect1.NavigateUrl = "Default.aspx";
                    hlkRedirect2.Visible = true;
                    hlkRedirect2.Text = "o comuniquese con el desarrollador.";
                    hlkRedirect2.NavigateUrl = "#";
                }
                
                // code 01 = Usuario o pass incorrectos
                else if (code == 01)
                {
                    hlkRedirect1.Visible = true;
                    hlkRedirect1.Text = "Iniciar sesión";
                    hlkRedirect1.NavigateUrl = "Login.aspx";

                }

                // code 02 = Sin permino de admin
                else if (code == 02)
                {
                    hlkRedirect1.Visible = true;
                    hlkRedirect1.Text = "Volver al inicio";
                    hlkRedirect1.NavigateUrl = "Default.aspx";
                }
            }
        }
    }
}