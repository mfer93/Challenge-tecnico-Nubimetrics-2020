using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2.BLL
{
    /// <summary>
    /// Establece una serie de cadenas que representan la ruta de acceso a los recursos de la API de MercadoLibre
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Devuelve el string con la ruta de acceso para consultar las monedas disponibles
        /// <returns></returns>
        public string Currencies()
        {
            return "/currencies/";
        }

        /// <summary>
        /// Devuelve el string con la ruta de acceso para realizar una busqueda del valor de conversion entre dos monedas
        /// </summary>
        /// <returns></returns>
        public string Currency_Conversions()
        {
            return "/currency_conversions/search";
        }
    }
}
