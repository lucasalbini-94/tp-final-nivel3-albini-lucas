using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using Servicios;

namespace Ventanas
{
    public partial class Articulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MarcaNegocio marca = new MarcaNegocio();
                CategoriaNegocio categoria = new CategoriaNegocio();
                ddlMarca.DataSource = marca.listarMarcas();
                ddlMarca.DataBind();
                ddlCategoria.DataSource = categoria.listarCategorias();
                ddlCategoria.DataBind();
            }
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
                Articulo seleccionado = lista.Find(x => x.Id == id);

                tbxCodigo.Text = seleccionado.Codigo;
                tbxNombre.Text = seleccionado.Nombre;
                tbxDescripcion.Text = seleccionado.Descripcion;
                ddlMarca.SelectedValue = seleccionado.Marca.Descripcion;
                ddlCategoria.SelectedValue = seleccionado.Categoria.Descripcion;
                tbxPrecio.Text = seleccionado.Precio.ToString("C2");
                if (Helper.validarUrl(seleccionado.ImagenUrl))
                    imgArticulo.ImageUrl = seleccionado.ImagenUrl;
                else
                {
                    imgArticulo.ImageUrl = "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg";
                }
            }
        }
    }
}