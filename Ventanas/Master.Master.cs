using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Servicios;

namespace Ventanas
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public Usuario UserActivo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay una sesión activa
                if (Session["user"] is null)
                {
                    // Restringir el acceso a las ventanas
                    if (!(Page is Default || Page is DescripcionArticulo))
                    {
                        Response.Redirect("Login.aspx", false);
                    }
                    
                    imgAvatar.ImageUrl = Helper.placeHolder();
                }
                else
                {
                    // Guardar el usuario en sesión
                    UserActivo = (Usuario)Session["user"];

                    // Verificar si tiene imágen de perfil
                    if (UserActivo.UrlImagenPerfil != null)
                    {
                        imgAvatar.ImageUrl = Helper.validarImagen(UserActivo.UrlImagenPerfil);
                    }
                    else
                    {
                        imgAvatar.ImageUrl = Helper.placeHolder();
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx?code=00");
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Borrar el usuario de la sesión y de la memoria
            UserActivo = null;
            Session.Clear();

            // Recargar página con sesión vacía
            Page_Load(sender, e);
        }
    }
}