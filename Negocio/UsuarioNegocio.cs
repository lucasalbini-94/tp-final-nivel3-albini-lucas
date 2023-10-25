using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, email, pass, nombre, apellido, urlImagenPerfil, admin from USERS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Email = (string)datos.Lector["email"];
                    aux.Pass = (string)datos.Lector["pass"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        aux.Apellido = (string)datos.Lector["apellido"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        aux.UrlImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    aux.Admin = (bool)datos.Lector["admin"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConeccion();
            }
        }

        public void agregarUsuario(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert Into USERS Values (@email, @pass, @nombre, @apellido, @urlImagenPerfil, 0)");
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@urlImagenPerfil", nuevo.UrlImagenPerfil);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConeccion();
            }
        }

        public void modificarUsuario(Usuario modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update USERS Set nombre = @nombre, apellido = @apellido, urlImagenPerfil = @urlImagenPerfil Where Id = @id");
                datos.setearParametro("@nombre", modificado.Nombre);
                datos.setearParametro("@apellido", modificado.Apellido);
                datos.setearParametro("@urlImagenPerfil", modificado.UrlImagenPerfil);
                datos.setearParametro("@id", modificado.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConeccion();
            }
        }

        public void eliminarUsuario(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete From USERS Where Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConeccion();
            }
        }

        public void cambiarNivel(bool admin, int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (admin)
                {
                    datos.setearConsulta("Update USERS Set Admin = 0 Where Id = @id");
                    datos.setearParametro("@id", id);
                    datos.ejecutarAccion();
                }
                else
                {
                    datos.setearConsulta("Update USERS Set Admin = 1 Where Id = @id");
                    datos.setearParametro("@id", id);
                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConeccion();
            }
        }
    }
}
