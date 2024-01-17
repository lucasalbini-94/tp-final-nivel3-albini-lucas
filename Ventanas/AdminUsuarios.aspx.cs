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
    public partial class AdminUsuarios : System.Web.UI.Page
    {
        private List<Usuario> ListaUsuarios;

        private List<Usuario> ListaFiltrada;

        public int CantUsuarios;

        public int IdUsuario;

        public bool SeccionUsuario = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Verificar que el usuario es admin
                if (Helper.esAdmin(Session["user"]))
                {
                    // Cargar tabla de usuarios con lista completa o filtrada
                    if (ListaFiltrada is null)
                    {
                        UsuarioNegocio negocio = new UsuarioNegocio();
                        ListaUsuarios = negocio.listarUsuarios();

                        // Guardar cantidad de usuarios en atributo
                        CantUsuarios = ListaUsuarios.Count();

                        dgvUsuarios.DataSource = ListaUsuarios;
                        dgvUsuarios.DataBind();
                    }
                    else
                    {
                        CantUsuarios = ListaFiltrada.Count();

                        dgvUsuarios.DataSource = ListaFiltrada;
                        dgvUsuarios.DataBind();
                    }

                    // Verifica si se ha seleccionado un usuario para cargar la sección
                    if (SeccionUsuario)
                    {
                        // Obtener el usuario seleccionado de la sesión
                        Usuario aux = (Usuario)Session["selectedUser"];
                        // Cargar mail
                        tbxEmail.Text = aux.Email;
                        // Definir acción sobre el usuario
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

        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Guardar el id de usuario en atributo
            IdUsuario = int.Parse(dgvUsuarios.SelectedDataKey.Value.ToString());
            // Guardar usuario seleccionado en sesión
            Session.Add("selectedUser", ListaUsuarios.Find(x => x.Id == IdUsuario));
            // Cambiar valor de atributo para mostrar sección en pantalla
            SeccionUsuario = true;
            // Recargar página
            Page_Load(sender, e);
        }

        protected void dgvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Controlar páginas de la grilla
            dgvUsuarios.PageIndex = e.NewPageIndex;
            dgvUsuarios.DataBind();
        }

        protected void lbtEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                // Eliminar usuario según id 
                negocio.eliminarUsuario(IdUsuario);
                // Cambiar atributo para ocultar sección de edición
                SeccionUsuario = false;
                // Recargar página
                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx?code=00", false);
            }

        }

        protected void lbtAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario aux = (Usuario)Session["selectedUser"];

                // Cambiar permisos de usuario
                negocio.cambiarNivel(aux.Admin, aux.Id);
                SeccionUsuario = false;
                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Session.Add("error", Helper.mensajeError(ex));
                Response.Redirect("Error.aspx?code=00", false);
            }
        }

        protected void tbxFiltroEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Aplicar filtro según email
                string filtro = tbxFiltroEmail.Text;
                ListaFiltrada = ListaUsuarios.FindAll(x => x.Email.ToLower().Contains(filtro.ToLower()));
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