using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace EX1.Models
{
    /// <summary>
    /// Devuelve una Lista de Parametros requeridos para la consulta de un servicio en particular de https://api.mercadolibre.com
    /// </summary>
    public class DefaultParameters
    {
        /// <summary>
        /// Parametros para setear el Offset en una busqueda
        /// </summary>
        /// <param name="offset">Offset Incial de la consulta</param>
        /// <param name="search_text">Texto a Buscar</param>
        /// <param name="access_token">Si se especifica, se añade el access_token como parámetro</param>
        /// <returns>Devuelve una Lista de Parametros</returns>
        public List<Parameter> Offset_Parameters(int offset, string search_text, string access_token = "")
        {
            List<Parameter> _Parameters = new List<Parameter>();

            if (access_token != "")
                _Parameters.Add(new Parameter()
                {
                    Name = "access_token",
                    Value = access_token
                });

            _Parameters.Add(new Parameter()
            {
                Name = "offset",
                Value = offset
            });

            _Parameters.Add(new Parameter()
            {
                Name = "q",
                Value = search_text
            });

            return _Parameters;
        }
    }
}