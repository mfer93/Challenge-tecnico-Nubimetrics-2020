using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EX1.Models
{
    /// <summary>
    /// Establece una serie de cadenas que representan la ruta de acceso a los recursos de la API de MercadoLibre
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Devuelve el string con la ruta de acceso para consultar las localidades de los Paises
        /// </summary>
        /// <param name="CodPais">Código del Pais a consultar</param>
        /// <returns></returns>
        public string ClassifiedLocations(string CodPais)
        {
            return "/classified_locations/countries/" + CodPais;
        }

        /// <summary>
        /// Devuelve el string con la ruta de acceso para consultar publicaciones que contengan una cadena especificada
        /// </summary>
        /// <param name="query">Cadena a buscar</param>
        /// <returns></returns>
        public string Search(string query)
        {
            return "/sites/MLA/search?q=" + query;
        }
    }
}