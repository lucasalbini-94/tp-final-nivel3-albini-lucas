using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Ventanas
{
    public partial class AdminMarCat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcaNegocio mNegocio = new MarcaNegocio();
            CategoriaNegocio cNegocio = new CategoriaNegocio();

            dgvMarcas.DataSource = mNegocio.listarMarcas();
            dgvMarcas.DataBind();
            dgvCategorias.DataSource = cNegocio.listarCategorias();
            dgvCategorias.DataBind();
        }

        protected void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxNuevaCategoria.Text != "")
                {
                    CategoriaNegocio cNegocio = new CategoriaNegocio();
                    Categoria nueva = new Categoria();

                    nueva.Descripcion = tbxNuevaCategoria.Text;
                    cNegocio.agregar(nueva);
                    Page_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnNuevaMarca_Click(object sender, EventArgs e)
        {
            try
            {
                if(tbxNuevaMarca.Text != "")
                {
                    MarcaNegocio mNegocio = new MarcaNegocio();
                    Marca nueva = new Marca();

                    nueva.Descripcion = tbxNuevaMarca.Text;
                    mNegocio.agregar(nueva);
                    Page_Load(sender, e);
                    tbxNuevaCategoria.Text = null;
                    tbxNuevaMarca.Text = null;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void dgvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(dgvCategorias.SelectedDataKey.Value.ToString());
            Response.Redirect("AdminMarCat.aspx?id=" + id + "&tipo=categoria");
        }

        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(dgvMarcas.SelectedDataKey.Value.ToString());
            Response.Redirect("AdminMarCat.aspx?id=" + id + "&tipo=marca");
        }
    }
}