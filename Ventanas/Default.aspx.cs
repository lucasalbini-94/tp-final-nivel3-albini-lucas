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

        public List<Articulo> ListaFiltrada { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio articulo = new ArticuloNegocio();
                ListaArticulos = articulo.listarArticulos();
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
                if (!IsPostBack)
                {
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
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string filtro = tbxBuscar.Text;
                ListaFiltrada = ListaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void filtroAvanzado_SelectedIndexChange(object sender, EventArgs e)
        {
            try
            {
                if (cbxFiltroAvanzado.Checked)
                {
                    ListaFiltrada = ListaArticulos.FindAll(x => x.Marca.Descripcion == ddlMarca.SelectedItem.Text).FindAll(x =>
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
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}