using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EX1.Models;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EX1.Controllers
{
    public class BusquedaController : Controller
    {
        /// <summary>
        /// Busca publicaciones de MercadoLibre que contengan un cadena especificada
        /// Solo muestra los primeros 50 resultados
        /// </summary>
        /// <param name="q">Cadena a buscar</param>
        /// <returns>JSON con la respuesta del servicio: https://api.mercadolibre.com/sites/MLA/search?q=xxx </returns>
        public JObject search(string q)
        {
            Busqueda busqueda = new Busqueda().GetMeli(q);
            return JObject.FromObject(busqueda);
        }

        /// <summary>
        /// Busca publicaciones de MercadoLibre que contengan un cadena especificada
        /// Muestra todos los resultados de la busqueda
        /// </summary>
        /// <param name="q">Cadena a buscar</param>
        /// <returns>JSON con la respuesta del servicio: https://api.mercadolibre.com/sites/MLA/search?q=xxx </returns>
        //public JObject searchallresult(string q)
        //{
        //    Busqueda busqueda = new Busqueda().GetMeli_AllResults(q);
        //    return JObject.FromObject(busqueda);
        //}
    }
}