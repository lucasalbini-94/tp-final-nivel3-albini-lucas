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
        public static bool validarUrl(string url)
        {
            try
            {
                HttpWebRequest consulta = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse respuesta = (HttpWebResponse)consulta.GetResponse();

                if (respuesta.StatusCode == HttpStatusCode.OK)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
