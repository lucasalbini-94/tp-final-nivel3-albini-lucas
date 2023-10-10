using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

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
            
        }
    }
}