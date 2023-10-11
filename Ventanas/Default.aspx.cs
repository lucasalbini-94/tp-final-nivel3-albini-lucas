using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Ventanas
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articulo = new ArticuloNegocio();
            ListaArticulos = articulo.listarArticulos();

            if (Session["listaArticulos"] is null)
            {
                Session.Add("listaArticulos", ListaArticulos);
            }

            repRepetidor.DataSource = ListaArticulos;
            repRepetidor.DataBind();
            if (!IsPostBack)
            {
                MarcaNegocio marca = new MarcaNegocio();
                CategoriaNegocio categoria = new CategoriaNegocio();

                ddlMarca.DataSource = marca.listarMarcas();
                ddlMarca.DataBind();
                ddlCategoria.DataSource = categoria.listarCategorias();
                ddlCategoria.DataBind();
            }
        }
    }
}