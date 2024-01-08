using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Servicios;

namespace Negocio
{
    public class FavoritosNegocio
    {
        public List<Articulo> listarFavoritos(int id)
        {
            List<Articulo> listaFavoritos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select IdArticulo from FAVORITOS where IdUser = @IdUser");
                datos.setearParametro("@IdUser", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["IdArticulo"];
                    cargarArticulo(ref aux);
                    listaFavoritos.Add(aux);
                }

                return listaFavoritos;
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

        private void cargarArticulo(ref Articulo aux)
        {
            List<Articulo> lista = new List<Articulo>();
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                int id = aux.Id;
                lista = negocio.listarArticulos();
                Articulo seleccionado = lista.Find(x => x.Id == id);

                aux.Nombre = seleccionado.Nombre;
                aux.Codigo = seleccionado.Codigo;
                aux.Descripcion = seleccionado.Descripcion;
                aux.Categoria = new Categoria();
                aux.Categoria.Id = seleccionado.Categoria.Id;
                aux.Categoria.Descripcion = seleccionado.Categoria.Descripcion;
                aux.Marca = new Marca();
                aux.Marca.Id = seleccionado.Marca.Id;
                aux.Marca.Descripcion = seleccionado.Marca.Descripcion;
                aux.ImagenUrl = seleccionado.ImagenUrl;
                aux.Precio = seleccionado.Precio;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarFavorito(int idUser, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete From FAVORITOS Where IdUser = @IdUser And IdArticulo = @IdArticulo");
                datos.setearParametro("IdUser", idUser);
                datos.setearParametro("IdArticulo", idArticulo);
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

        public void agregarFavorito(int idUser, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert Into FAVORITOS Values (@IdUser, @IdArticulo)");
                datos.setearParametro("@IdUser", idUser);
                datos.setearParametro("IdArticulo", idArticulo);
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
    }
}
