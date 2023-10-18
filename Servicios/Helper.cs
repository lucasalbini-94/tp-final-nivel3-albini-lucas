using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

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
                    
                    return "~/Images/ImagesArt/" + direccion;
                }
                else
                    return "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg";
            }
            catch (Exception)
            {
                return "https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg";
            }
        }
    }
}
