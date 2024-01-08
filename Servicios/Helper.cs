using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Dominio;

namespace Servicios
{
    public static class Helper
    {
        public static string validarImagen(string direccion)
        {
            try
            {
                if (direccion.ToLower().Contains("http"))
                {
                    HttpWebRequest consulta = (HttpWebRequest)WebRequest.Create(direccion);
                    HttpWebResponse respuesta = (HttpWebResponse)consulta.GetResponse();

                    if (respuesta.StatusCode == HttpStatusCode.OK)
                        return direccion;
                    else
                        return "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg";
                }
                else if (!string.IsNullOrEmpty(direccion))
                {
                    if (direccion.ToLower().Contains("perfil"))
                        return "~/Images/ImagePerfil/" + direccion;
                    else
                        return "~/ImagesArt" + direccion;
                }
                else
                    return "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg";
            }
            catch (Exception)
            {
                return "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg";
            }
        }

        public static string placeHolder()
        {
            return "https://png.pngtree.com/png-clipart/20210915/ourlarge/pngtree-user-avatar-placeholder-black-png-image_3918427.jpg";
        }

        public static string mensajeError(Exception ex)
        {
            return ex.Message;
        }

        public static bool esAdmin(object user)
        {
            Usuario aux = (Usuario)user;
            if (aux.Admin)
                return true;
            else
                return false;
        }
    }
}
