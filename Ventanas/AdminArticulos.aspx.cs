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
    public partial class ListaArticulos : System.Web.UI.Page
    {
        public List<Articulo> Lista { get; set; }

        public List<Articulo> ListaFiltrada { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Verificar que el usuario es admin
                if (Helper.esAdmin(Session["user"]))
                {
                    //Verivicar si se debe mostrar la lista completa o la lista filtrada
                    if (ListaFiltrada is null)
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        Lista = negocio.listarArticulos();
                        dgvArticulos.DataSource = Lista;
                        dgvArticulos.DataBind();
                    }
                    else
                    {
                        dgvArticulos.DataSource = ListaFiltrada;
                        dgvArticulos.DataBind();
                    }
                }
                else
                {
                    Session.Add("error", "No tiene permiso para acceder a esta página");
                    Response.Redirect("Error.aspx?code=02", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx?code=00", false);
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seleccionar un articulo de la lista por id
            int id = int.Parse(dgvArticulos.SelectedDataKey.Value.ToString());
            Response.Redirect("Articulo.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Controlar páginas de la GridView
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void tbxCodigo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Aplicar filtro según código
                string filtro = tbxCodigo.Text;
                ListaFiltrada = Lista.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()));
                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx?code=00", false);
            }
        }

        protected void tbxArticulo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Aplicar filtro según nombre de articulo
                string filtro = tbxArticulo.Text;
                ListaFiltrada = Lista.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
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