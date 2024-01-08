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
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> ListaFavoritos { get; set; }
        public Usuario user { get; set; }
        public bool listaVacia;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] is null)
                Response.Redirect("Login.aspx", false);
            else
            {
                FavoritosNegocio favoritoNegocio = new FavoritosNegocio();

                try
                {
                    // Traer ids de articulos favoritos del usuario
                    user = (Usuario)Session["user"];
                    ListaFavoritos = favoritoNegocio.listarFavoritos(user.Id);

                    // Verificar si hay articulos en la lista
                    if (ListaFavoritos != null && ListaFavoritos.Count > 0)
                    {
                        listaVacia = false;
                        repFavoritos.DataSource = ListaFavoritos;
                        repFavoritos.DataBind();
                    }
                    else
                    {
                        listaVacia = true;
                        lblMensaje.Text = "Aún no ha agregado artículos favoritos";
                    }
                }
                catch (Exception ex)
                {
                    Session.Add("error", Helper.mensajeError(ex));
                    Response.Redirect("Error.aspx?code=00", false);
                }
            }
        }

        protected void btnQuitarFavoritos_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener id de usuario y id de articulo
                int idArticulo = int.Parse(((Button)sender).CommandArgument);
                int idUser = user.Id;
                // Lógica de eliminación de favorito
                FavoritosNegocio negocio = new FavoritosNegocio();
                negocio.eliminarFavorito(idUser, idArticulo);
                ListaFavoritos = negocio.listarFavoritos(user.Id);
                if (ListaFavoritos is null || ListaFavoritos.Count == 0)
                    listaVacia = true;
                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx?code=00", false);
            }
        }
    }
}