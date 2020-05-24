using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace EX2.BLL
{
    /// <summary>
    /// Devuelve una Lista de Parametros requeridos para la consulta de un servicio en particular de https://api.mercadolibre.com
    /// </summary>
    public class DefaultParameters
    {
        /// <summary>
        /// Parámetros para consultar el coeficiente de conversion de una moneda a otra
        /// </summary>
        /// <param name="from">Moneda Origen</param>
        /// <param name="to">Moneda Destino</param>
        /// <returns>Lista de Parámetros</returns>
        public List<Parameter> CurrencyConversion(string from, string to)
        {
            List<Parameter> _Parameters = new List<Parameter>();

            _Parameters.Add(new Parameter()
            {
                Name = "from",
                Value = from
            });

            _Parameters.Add(new Parameter()
            {
                Name = "to",
                Value = to
            });

            return _Parameters;
        }
    }
}
