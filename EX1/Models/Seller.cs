using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EX1.Models
{
    /// <summary>
    /// Clase para almacenar la estructura JSON del servicio https://api.mercadolibre.com
    /// </summary>
    public class Seller
    {
        public long seller_id { get; set; }

        public Seller()
        {
            this.seller_id = 0;
        }
    }
}