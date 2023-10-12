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
            if (Session["listaArticulos"] is null)
            {
                ArticuloNegocio articulo = new ArticuloNegocio();
                Session.Add("listaArticulos", articulo.listarArticulos());
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
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "Id";
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo nuevo = new Articulo();
                nuevo.Codigo = tbxCodigo.Text;
                nuevo.Nombre = tbxNombre.Text;
                nuevo.Descripcion = tbxDescripcion.Text;
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Precio = decimal.Parse(tbxPrecio.Text);

                if (!string.IsNullOrEmpty(tbxImagen.Value))
                {
                    string ruta = Server.MapPath("./Images/ImagesArt/");
                    tbxImagen.PostedFile.SaveAs(ruta + "art-" + nuevo.Codigo + "-" + DateTime.Now.ToString("dd-MM-yyyy") + "-img.jpg");
                    nuevo.ImagenUrl = "art-" + nuevo.Codigo + "-" + DateTime.Now.ToString("dd-MM-yyyy") + "-img.jpg";
                }
                else
                {
                    nuevo.ImagenUrl = "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg";
                }

                negocio.agregar(nuevo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}