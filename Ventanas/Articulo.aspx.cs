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
            try
            {
                // Verificar si el usuario es admin
                if (Helper.esAdmin(Session["user"]))
                {
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                    // Si no es una recarga de página cargar desplegables
                    if (!IsPostBack)
                    {
                        MarcaNegocio marcaNegocio = new MarcaNegocio();
                        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                        ddlMarca.DataSource = marcaNegocio.listarMarcas();
                        ddlMarca.DataTextField = "Descripcion";
                        ddlMarca.DataValueField = "Id";
                        ddlMarca.DataBind();
                        ddlCategoria.DataSource = categoriaNegocio.listarCategorias();
                        ddlCategoria.DataTextField = "Descripcion";
                        ddlCategoria.DataValueField = "Id";
                        ddlCategoria.DataBind();
                    }
                    // Verificar si hay un id en la URL y si es una recarga de página
                    if (Request.QueryString["id"] != null && !IsPostBack)
                    {
                        // Deshabilitar el boton de agregar
                        btnAgregar.Enabled = false;
                        // Obtener el id de la URL
                        int id = int.Parse(Request.QueryString["id"].ToString());
                        List<Articulo> lista = articuloNegocio.listarArticulos();
                        // Obtener el articulo de la lista por el id
                        Articulo seleccionado = lista.Find(x => x.Id == id);

                        // Cargar los datos del articulo
                        tbxCodigo.Text = seleccionado.Codigo;
                        tbxNombre.Text = seleccionado.Nombre;
                        tbxDescripcion.Text = seleccionado.Descripcion;
                        ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                        ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                        tbxPrecio.Text = seleccionado.Precio.ToString("0.00");
                        if (seleccionado.ImagenUrl.ToLower().Contains("http"))
                            tbxImagenUrl.Text = seleccionado.ImagenUrl;
                        imgArticulo.ImageUrl = Helper.validarImagen(seleccionado.ImagenUrl);
                    }
                    else
                    {
                        // Deshabilitar botones que no se necesitan
                        btnModificar.Enabled = false;
                        lbtEliminar.Enabled = false;
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
                Response.Redirect("Error.aspx?code=00");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Lógica para agregar un articulo en la DB
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo nuevo = new Articulo();
                cargarDatos(nuevo);
                negocio.agregar(nuevo);
                // Redirigir a la lista de articulos
                Response.Redirect("AdminArticulos.aspx", false);
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
                // Logica para modificación de artículo
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo seleccionado = new Articulo();
                cargarDatos(seleccionado);
                seleccionado.Id = int.Parse(Request.QueryString["id"]);
                negocio.modificar(seleccionado);
                // Redirigir a la lista de artículos
                Response.Redirect("AdminArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx?code=00");
            }
        }

        protected void lbtEliminar_Click(object sender, EventArgs e)
        {
            // Logica para eliminar articulo
            ArticuloNegocio negocio = new ArticuloNegocio();
            negocio.eliminar(int.Parse(Request.QueryString["id"]));
            Response.Redirect("AdminArticulos.aspx", false);
        }

        public void cargarDatos(Articulo articulo)
        {
            try
            {
                string ruta;
                // Cargar datos de los controles al objeto
                articulo.Codigo = tbxCodigo.Text;
                articulo.Nombre = tbxNombre.Text;
                articulo.Descripcion = tbxDescripcion.Text;
                articulo.Marca = new Marca();
                articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                articulo.Precio = decimal.Parse(tbxPrecio.Text);

                // Verificar si fué cargada una imagen local
                if (!string.IsNullOrEmpty(tbxImagen.Value))
                {
                    ruta = Server.MapPath("./Images/ImagesArt/");
                    tbxImagen.PostedFile.SaveAs(ruta + "art-" + articulo.Codigo + "-" + DateTime.Now.ToString("dd-MM-yyyy") + "-img.jpg");
                    articulo.ImagenUrl = "art-" + articulo.Codigo + "-" + DateTime.Now.ToString("dd-MM-yyyy") + "-img.jpg";
                }
                // Verificar si se cargó una imágen por URL
                else if (!string.IsNullOrEmpty(tbxImagenUrl.Text))
                    articulo.ImagenUrl = tbxImagenUrl.Text;
                // Si no se cargó una imagen, asignar imagen por defecto
                else
                    articulo.ImagenUrl = "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg";

            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx?code=00");
            }
        }
    }
}