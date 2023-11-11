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
                if (Helper.esAdmin(Session["user"]))
                {
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
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
                    if (Request.QueryString["id"] != null && !IsPostBack)
                    {
                        btnAgregar.Enabled = false;
                        int id = int.Parse(Request.QueryString["id"].ToString());
                        List<Articulo> lista = articuloNegocio.listarArticulos();
                        Articulo seleccionado = lista.Find(x => x.Id == id);

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
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo nuevo = new Articulo();
                cargarDatos(nuevo);
                negocio.agregar(nuevo);
                Response.Redirect("AdminArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo seleccionado = new Articulo();
                cargarDatos(seleccionado);
                seleccionado.Id = int.Parse(Request.QueryString["id"]);
                negocio.modificar(seleccionado);
                Response.Redirect("AdminArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx");
            }
        }

        protected void lbtEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            negocio.eliminar(int.Parse(Request.QueryString["id"]));
            Response.Redirect("AdminArticulos.aspx", false);
        }

        public void cargarDatos(Articulo articulo)
        {
            try
            {
                string ruta;
                articulo.Codigo = tbxCodigo.Text;
                articulo.Nombre = tbxNombre.Text;
                articulo.Descripcion = tbxDescripcion.Text;
                articulo.Marca = new Marca();
                articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                articulo.Precio = decimal.Parse(tbxPrecio.Text);

                if (!string.IsNullOrEmpty(tbxImagen.Value))
                {
                    ruta = Server.MapPath("./Images/ImagesArt/");
                    tbxImagen.PostedFile.SaveAs(ruta + "art-" + articulo.Codigo + "-" + DateTime.Now.ToString("dd-MM-yyyy") + "-img.jpg");
                    articulo.ImagenUrl = "art-" + articulo.Codigo + "-" + DateTime.Now.ToString("dd-MM-yyyy") + "-img.jpg";
                }
                else if (!string.IsNullOrEmpty(tbxImagenUrl.Text))
                    articulo.ImagenUrl = tbxImagenUrl.Text;
                else
                    articulo.ImagenUrl = "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg";

            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx");
            }
        }
    }
}