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
    public partial class AdminUsuarios : System.Web.UI.Page
    {
        public List<Usuario> ListaUsuarios;

        public int CantUsuarios;

        public int IdUsuario;

        public bool SeccionUsuario = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                ListaUsuarios = negocio.listarUsuarios();
                CantUsuarios = ListaUsuarios.Count();
                dgvUsuarios.DataSource = ListaUsuarios;
                dgvUsuarios.DataBind();
                if (SeccionUsuario)
                {
                    Usuario aux = (Usuario)Session["usuario"];
                    tbxEmail.Text = aux.Email;
                    if (aux.Admin)
                    {
                        lbtAdmin.Text = "Quitar admin";
                    }
                    else
                    {
                        lbtAdmin.Text = "Hacer admin";
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            IdUsuario = int.Parse(dgvUsuarios.SelectedDataKey.Value.ToString());
            Session.Add("usuario", ListaUsuarios.Find(x => x.Id == IdUsuario));
            SeccionUsuario = true;
            Page_Load(sender, e);
        }

        protected void dgvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvUsuarios.PageIndex = e.NewPageIndex;
            dgvUsuarios.DataBind();
        }

        protected void lbtEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario aux = (Usuario)Session["usuario"];
                negocio.eliminarUsuario(IdUsuario);
                SeccionUsuario = false;
                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void lbtAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario aux = (Usuario)Session["usuario"];
                negocio.cambiarNivel(aux.Admin, aux.Id);
                SeccionUsuario = false;
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