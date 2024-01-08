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
    public partial class Perfil : System.Web.UI.Page
    {
        public Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] is null)
                Response.Redirect("Login.Aspx");
            else
            {
                try
                {
                    if (!IsPostBack)
                    {
                        usuario = new Usuario();
                        usuario = (Usuario)Session["user"];

                        // Cargar campos
                        tbxEmail.Text = usuario.Email;
                        if (usuario.Nombre != null)
                            tbxNombre.Text = usuario.Nombre;
                        if (usuario.Apellido != null)
                            tbxApellido.Text = usuario.Apellido;
                        if (usuario.UrlImagenPerfil != null)
                            imgPerfil.ImageUrl = Helper.validarImagen(usuario.UrlImagenPerfil);
                        else
                            imgPerfil.ImageUrl = Helper.placeHolder();
                    }
                }
                catch (Exception ex)
                {
                    Session.Add("error", Helper.mensajeError(ex));
                    Response.Redirect("Error.aspx?code=00", false);
                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                if (usuario is null)
                    usuario = (Usuario)Session["user"];
                usuario.Nombre = tbxNombre.Text;
                usuario.Apellido = tbxApellido.Text;

                // Cargar imágen de avatar si existe
                if (tbxImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/ImagePerfil/");
                    tbxImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Email + DateTime.Now.ToString("dd-MM-yy") +
                        ".jpg");
                    usuario.UrlImagenPerfil = "perfil-" + usuario.Email + DateTime.Now.ToString("dd-MM-yy") + ".jpg";
                }
                negocio.modificarUsuario(usuario);

                // Leer imágen
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/ImagePerfil/" + usuario.UrlImagenPerfil;
                imgPerfil.ImageUrl = "~/Images/ImagePerfil/" + usuario.UrlImagenPerfil;

            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx?code=00", false);
            }

        }
    }
}