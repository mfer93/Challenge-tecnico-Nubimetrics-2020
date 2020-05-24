using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MercadoLibre;
using RestSharp;
using System.Net;
using Newtonsoft.Json;

namespace EX1.Models
{
    /// <summary>
    /// Clase para almacenar la estructura JSON del servicio https://api.mercadolibre.com
    /// </summary>
    public class Pais
    {
        public string id { get; set; }
        public string name { get; set; }
        public string locale { get; set; }
        public string currency_id { get; set; }
        public string decimal_separator { get; set; }
        public string thousands_separator { get; set; }
        public string time_zone { get; set; }
        Geo_information geo_information;

        public Pais()
        {
            this.id = "";
            this.name = "";
            this.locale = "";
            this.currency_id = "";
            this.decimal_separator = "";
            this.thousands_separator = "";
            this.time_zone = "";
            this.geo_information = new Geo_information();
        }

        public Pais GetMeli(string CodPais)
        {
            string resource = new Resource().ClassifiedLocations(CodPais);
            MercadoLibre.SDK.Meli meli = new MercadoLibre.SDK.Meli(0, "", "");
            Pais _pais = new Pais();

            IRestResponse response = meli.Get(resource);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                _pais = (Pais)JsonConvert.DeserializeObject<Pais>(response.Content);
            }

            return _pais;
        }
    }

    /// <summary>
    /// Clase para almacenar la estructura JSON del servicio https://api.mercadolibre.com
    /// </summary>
    public class Geo_information
    {
        Location location;

        public Geo_information()
        {
            this.location = new Location();
        }
    }

    /// <summary>
    /// Clase para almacenar la estructura JSON del servicio https://api.mercadolibre.com
    /// </summary>
    public class Location
    {
        public double latitude { get; set; }
        public double longitude { get; set; }

        public Location()
        {
            this.latitude = 0;
            this.longitude = 0;
        }
    }

    /// <summary>
    /// Clase para almacenar la estructura JSON del servicio https://api.mercadolibre.com
    /// </summary>
    public class States
    {
        public string id { get; set; }
        public string name { get; set; }

        public States()
        {
            this.id = "";
            this.name = "";
        }
    }
}