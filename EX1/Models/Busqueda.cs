using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using System.Net;
using Newtonsoft.Json;

namespace EX1.Models
{
    /// <summary>
    /// Clase para almacenar la estructura JSON del servicio https://api.mercadolibre.com
    /// </summary>
    public class Busqueda
    {
        public string site_id { get; set; }
        public string query { get; set; }
        public Paging paging { get; set; }
        public List<Results> results { get; set; }

        public Busqueda()
        {
            this.site_id = "";
            this.query = "";
            this.paging = new Paging();
            this.results = new List<Results>();
        }

        /// <summary>
        /// Realiza la conexion y consulta del servicio https://api.mercadolibre.com/sites/MLA/search?q=xxx
        /// </summary>
        /// <param name="query">Frase a buscar</param>
        /// <returns>Devuelve un objeto busqueda con una lista de los primero 50 resultados</returns>
        public Busqueda GetMeli(string query)
        {
            Busqueda busqueda = new Busqueda();
            MercadoLibre.SDK.Meli meli = new MercadoLibre.SDK.Meli(0, "");
            string resource = new Resource().Search(query);

            IRestResponse response = meli.Get(resource);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                busqueda = (Busqueda)JsonConvert.DeserializeObject<Busqueda>(response.Content);
            }

            return busqueda;
        }

        /// <summary>
        /// Realiza la conexion y consulta del servicio https://api.mercadolibre.com/sites/MLA/search?q=
        /// </summary>
        /// <param name="query">Frase a buscar</param>
        /// <returns>Devuelve un objeto busqueda con una lista de todos los resultados</returns>
        //public Busqueda GetMeli_AllResults(string query)
        //{
        //    Busqueda busqueda = new Busqueda();
        //    MercadoLibre.SDK.Meli meli = new MercadoLibre.SDK.Meli(0, "");
        //    string resource = new Resource().Search(query);


        //    IRestResponse response = meli.Get(resource);
        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        busqueda = (Busqueda)JsonConvert.DeserializeObject<Busqueda>(response.Content);

        //        while (!busqueda.paging.EsTotal())
        //        {
        //            busqueda.paging.NextOffset();
        //            List<Parameter> parameters = new DefaultParameters().Offset_Parameters(busqueda.paging.offset, query);
        //            response = meli.Get(resource, parameters);

        //            Busqueda _busqueda = (Busqueda)JsonConvert.DeserializeObject<Busqueda>(response.Content);

        //            foreach (Results results in _busqueda.results)
        //            {
        //                busqueda.results.Add(results);
        //            }
        //        }
        //    }


        //    return busqueda;
        //}

    }

    /// <summary>
    /// Clase para almacenar la estructura JSON Paging del servicio https://api.mercadolibre.com
    /// </summary>
    public class Paging
    {
        public int total { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public int primary_results { get; set; }

        public Paging()
        {
            this.total = 0;
            this.offset = -1;
            this.limit = 0;
            this.primary_results = 0;
        }

        public bool EsTotal()
        {
            if ((this.limit + this.offset) < this.total)
                return false;
            else
                return true;
        }

        public void NextOffset()
        {
            this.offset = this.offset + this.limit;
        }

    }

    /// <summary>
    /// Clase para almacenar la estructura JSON Results del servicio https://api.mercadolibre.com
    /// </summary>
    public class Results
    {
        public string id { get; set; }
        public string site_id { get; set; }
        public string tittle { get; set; }
        public double price { get; set; }
        public string permalink { get; set; }
        public Seller seller { get; set; }

        public Results()
        {
            this.id = "";
            this.site_id = "";
            this.tittle = "";
            this.price = 0;
            this.permalink = "";
            this.seller = new Seller();
        }
    }
}