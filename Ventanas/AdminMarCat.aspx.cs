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
    public partial class AdminMarCat1 : System.Web.UI.Page
    {
        private int id;
        private string tipo;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Verificar si el usuario es admin
                if (Helper.esAdmin(Session["user"]))
                {
                    // Otener por URL el Id y el tipo de objeto
                    id = int.Parse(Request.QueryString["id"].ToString());
                    tipo = Request.QueryString["tipo"];

                    // Si no es una redirección, cargar los datos del objeto seleccionado
                    if (!IsPostBack)
                    {
                        // Si es de tipo Marca
                        if (tipo == "marca")
                        {
                            MarcaNegocio negocio = new MarcaNegocio();
                            List<Marca> lista = negocio.listarMarcas();
                            Marca seleccionada = lista.Find(x => x.Id == id);

                            tbxDescripcion.Text = seleccionada.Descripcion;
                        }
                        //Si es de tipo Categoria
                        else if (tipo == "categoria")
                        {
                            CategoriaNegocio negocio = new CategoriaNegocio();
                            List<Categoria> lista = negocio.listarCategorias();
                            Categoria seleccionada = lista.Find(x => x.Id == id);

                            tbxDescripcion.Text = seleccionada.Descripcion;
                        }
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

        protected void lbtEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Eliminar de la lista según el tipo de objeto
                if(tipo == "categoria")
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    negocio.eliminar(id);
                    Response.Redirect("MarCat.aspx", false);
                }
                else if (tipo == "marca")
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    negocio.eliminar(id);
                    Response.Redirect("MarCat.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx?code=00");
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Modificar según el tipo de objeto
                if (tipo == "categoria")
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    Categoria seleccionada = new Categoria();

                    seleccionada.Descripcion = tbxDescripcion.Text;
                    seleccionada.Id = id;
                    negocio.modificar(seleccionada);
                    Response.Redirect("MarCat.aspx", false);
                }
                else if (tipo == "marca")
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    Marca seleccionada = new Marca();

                    seleccionada.Descripcion = tbxDescripcion.Text;
                    seleccionada.Id = id;
                    negocio.modificar(seleccionada);
                    Response.Redirect("MarCat.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx?code=00");
            }
        }
    }
}