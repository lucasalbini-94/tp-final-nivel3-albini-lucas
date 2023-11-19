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
    public partial class DescripcionArticulo : System.Web.UI.Page
    {
        public Articulo seleccionado;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                // Guardar el id de artículo que se recibe por URL y asignar a la propiedad seleccionado
                int id = int.Parse(Request.QueryString["id"].ToString());
                seleccionado = negocio.seleccionar(id);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx?code=00", false);
            }
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            // Lógica en proceso de planificación
        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            // Lógica en proceso de planificación
        }
    }
}