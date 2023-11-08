﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

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
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(dgvArticulos.SelectedDataKey.Value.ToString());
            Response.Redirect("Articulo.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void tbxCodigo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = tbxCodigo.Text;
                ListaFiltrada = Lista.FindAll(x => x.Codigo.ToUpper().Contains(filtro.ToUpper()));
                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void tbxArticulo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = tbxArticulo.Text;
                ListaFiltrada = Lista.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}