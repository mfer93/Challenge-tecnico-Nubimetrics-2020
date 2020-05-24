using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using System.Net;

namespace EX2.BLL
{
    /// <summary>
    /// Clase para almacenar la estructura JSON del servicio https://api.mercadolibre.com
    /// </summary>
    public class Currency
    {
        public string id { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public int decimal_places { get; set; }

        public double todolar { get; private set; } //Agregado para almacenar el valor de Conversion

        /// <summary>
        /// Realiza la conexion y Consulta de las Monedas disponibles del servicio https://api.mercadolibre.com
        /// </summary>
        /// <returns>Lista de Monedas</returns>
        public List<Currency> GetMeli()
        {
            List<Currency> currencies = new List<Currency>();
            MercadoLibre.SDK.Meli meli = new MercadoLibre.SDK.Meli(0, "");
            string resource = new Resource().Currencies();
            IRestResponse response = meli.Get(resource);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                currencies = JsonConvert.DeserializeObject<List<Currency>>(response.Content);
            }

            return currencies;
        }

        /// <summary>
        /// Realiza el calculo del coeficiente de conversion para cada Moneda de una Lista de Monedas Especificada
        /// </summary>
        /// <param name="Currencies">Lista de Monedas</param>
        /// <param name="to">Moneda Destino, si no se especifica se considera el Dolar USD</param>
        /// <returns>Lista de Monedas con sus respectivos Coeficiente de Conversion</returns>
        public List<Currency> Conversions(List<Currency> Currencies, string to = "USD")
        {
            List<Currency> conversions = new List<Currency>();

            foreach (Currency currency in Currencies)
            {
                currency.CurrencyConversion(to);
                conversions.Add(currency);
            }
            return conversions;
        }

        public bool CurrencyConversion(string to = "USD")
        {
            bool ok = false;

            MercadoLibre.SDK.Meli meli = new MercadoLibre.SDK.Meli(0, "");
            string resource = new Resource().Currency_Conversions();
            List<Parameter> parameters = new DefaultParameters().CurrencyConversion(this.id, to);

            IRestResponse response = meli.Get(resource, parameters);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                CurrencyConversion conversion = JsonConvert.DeserializeObject<CurrencyConversion>(response.Content);
                this.todolar = conversion.ratio;
                ok = true;
            }
            else //Si no se encuentra el valor o no se puede acceder al recurso
            {
                this.todolar = -1;
            }

            return ok;
        }
    }

    public class CurrencyConversion
    {
        public double ratio { get; set; }
    }
}
