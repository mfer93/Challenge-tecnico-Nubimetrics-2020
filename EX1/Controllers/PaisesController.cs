using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using EX1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EX1.Controllers
{
    public class PaisesController : Controller
    {
        public ActionResult get(string id)
        {
            HttpStatusCodeResult httpStatusCodeResult;

            switch (id.ToUpper())
            {
                case "AR":
                    Pais pais = new Pais().GetMeli("AR"); //Consume el servicio https://api.mercadolibre.com/classified_locations/countries/AR
                    httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.OK);
                    break;
                case "BR":
                    httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                    break;
                case "CO":
                    httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                    break;
                default:
                    httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    break;
            }
            return httpStatusCodeResult;
        }
    }
}