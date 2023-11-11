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

            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx");
            }
            if (Session["user"] is null)
            {
                if (!(Page is Default || Page is DescripcionArticulo))
                {
                    Response.Redirect("Login.aspx", false);
                }
                imgAvatar.ImageUrl = "https://png.pngtree.com/png-clipart/20210915/ourlarge/pngtree-user-avatar-placeholder-black-png-image_3918427.jpg";
            }
            else
            {
                UserActivo = (Usuario)Session["user"];
                if (UserActivo.UrlImagenPerfil != null)
                {
                    imgAvatar.ImageUrl = UserActivo.UrlImagenPerfil;
                }
                else
                {
                    imgAvatar.ImageUrl = "https://png.pngtree.com/png-clipart/20210915/ourlarge/pngtree-user-avatar-placeholder-black-png-image_3918427.jpg";
                }
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            UserActivo = null;
            Session.Clear();
            Page_Load(sender, e);
        }
    }
}