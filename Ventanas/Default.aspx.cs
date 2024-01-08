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
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar datos de artículos en la colección ListaArticulos
                ArticuloNegocio articulo = new ArticuloNegocio();
                if (ListaArticulos is null)
                    ListaArticulos = articulo.listarArticulos();

                // Verificar si el filtro avanzado está seleccionado
                if (cbxFiltroAvanzado.Checked)
                {
                    tbxBuscar.Enabled = false;
                    btnBuscar.Enabled = false;
                }
                else
                {
                    tbxBuscar.Enabled = true;
                    btnBuscar.Enabled = true;
                }

                // Verificar si se está recargando la página
                if (!IsPostBack)
                {
                    // Cargar los desplegables
                    MarcaNegocio marca = new MarcaNegocio();
                    CategoriaNegocio categoria = new CategoriaNegocio();

                    ddlMarca.DataSource = marca.listarMarcas();
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();
                    ddlCategoria.DataSource = categoria.listarCategorias();
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }
                // Cargar repetidor
                repRepetidor.DataSource = ListaArticulos;
                repRepetidor.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx?code=00");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Guardar el texto del buscador
                ArticuloNegocio negocio = new ArticuloNegocio();
                string filtro = tbxBuscar.Text;
                // Aplicar la búsqueda en ListaArticulos y guardar el resultado
                ListaArticulos = negocio.listarArticulos().FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
                // Vaciar repetidor
                repRepetidor.DataSource = null;
                //Recargar página
                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx?code=00");
            }
        }

        protected void filtroAvanzado_SelectedIndexChange(object sender, EventArgs e)
        {
            try
            {
                if (cbxFiltroAvanzado.Checked)
                {
                    ListaArticulos = ListaArticulos.FindAll(x => x.Marca.Descripcion == ddlMarca.SelectedItem.Text).FindAll(x =>
                            x.Categoria.Descripcion == ddlCategoria.SelectedItem.Text);
                    Page_Load(sender, e);
                }
                else
                {
                    Page_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx?code=00", false);
            }
        }

        public string cargarImagen(string direccion)
        {
            if (direccion.ToLower().Contains("http"))
            {
                return direccion;
            }
            else
            {
                return "/Image/ImageArt/" + direccion;
            }
        }

        protected void btnFavoritos_Click(object sender, EventArgs e)
        {
            try
            {
                int idArticulo = int.Parse(((Button)sender).CommandArgument);
                FavoritosNegocio negocio = new FavoritosNegocio();
                int idUser = ((Usuario)Session["user"]).Id;
                negocio.agregarFavorito(idUser, idArticulo);
            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx?cpde=00", false);
            }
        }
    }
}