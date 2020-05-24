using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EX1.Models;

namespace EX1.Controllers
{
    public class UsuariosController : Controller
    {
        /// <summary>
        /// Obtiene la informacion de todos los usuarios de la Tabla User
        /// </summary>
        /// <returns>JSON con la toda la informacion de los usuarios</returns>
        public JObject Get()
        {
            List<Usuario> usuarios = new Usuario().ObtenerUsuariosDB();
            JObject jsonresult = new JObject();
            jsonresult["users"] = JToken.FromObject(usuarios);
            return jsonresult;
        }

        /// <summary>
        /// Agrega un Usuario a la Tabla User
        /// </summary>
        /// <param name="nombre">Nombre del Usuario</param>
        /// <param name="apellido">Apellido del Usuario</param>
        /// <param name="email">Email del Usuario</param>
        /// <param name="password">Contraseña del Usuario</param>
        /// <returns>200 si el proceso se ejecutó con normalidad
        /// 500 si hubo algun error durante el proceso</returns>
        [HttpPut]
        public ActionResult Insert(string nombre, string apellido, string email, string password)
        {
            try
            {
                Usuario usuario = new Usuario();
                if (!string.IsNullOrEmpty(Request.QueryString["nombre"]))
                    usuario.nombre = Request.QueryString["nombre"];

                if (!string.IsNullOrEmpty(Request.QueryString["apellido"]))
                    usuario.apellido = Request.QueryString["apellido"];

                if (!string.IsNullOrEmpty(Request.QueryString["email"]))
                    usuario.email = Request.QueryString["email"];

                if (!string.IsNullOrEmpty(Request.QueryString["password"]))
                    usuario.password = new MD5().Encrypt(Request.QueryString["password"]); //Se crea el Hash MD5 equivalente para la cadena

                usuario.AltaUsuario();

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

        }

        /// <summary>
        /// Elimina un Usuario de la Tabla User
        /// </summary>
        /// <param name="id">ID del Usuario a eliminar</param>
        /// <returns>200 si el proceso se ejecutó con normalidad
        /// 400 si no se logra convertir el id a un número
        /// 500 si hubo algun error durante el proceso</returns>
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            try
            {
                Usuario usuario = new Usuario();
                if (Int64.TryParse(Request.QueryString["id"], out long Id))
                    usuario.id = Id;
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                usuario.BajaUsuario();
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Modifica un Usuario de la Tabla User
        /// </summary>
        /// <param name="id">ID del Usuario a modificar</param>
        /// <param name="nombre">Nombre del Usuario</param>
        /// <param name="apellido">Apellido del Usuario</param>
        /// <param name="email">Email del Usuario</param>
        /// <param name="password">Contraseña del Usuario</param>
        /// <returns>200 si el proceso se ejecutó con normalidad
        /// 400 si no se logra convertir el id a un número
        /// 500 si hubo algun error durante el proceso</returns>
        [HttpPost]
        public ActionResult Update(long id, string nombre, string apellido, string email, string password)
        {
            try
            {
                Usuario usuario = new Usuario();

                if (long.TryParse(Request.QueryString["id"], out long Id))
                    usuario.id = Id;
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                if (!string.IsNullOrEmpty(Request.QueryString["nombre"]))
                    usuario.nombre = Request.QueryString["nombre"];

                if (!string.IsNullOrEmpty(Request.QueryString["apellido"]))
                    usuario.apellido = Request.QueryString["apellido"];

                if (!string.IsNullOrEmpty(Request.QueryString["email"]))
                    usuario.email = Request.QueryString["email"];

                if (!string.IsNullOrEmpty(Request.QueryString["password"]))
                    usuario.password = new MD5().Encrypt(Request.QueryString["password"]); //Se crea el Hash MD5 equivalente para la cadena

                usuario.ModificaUsuario();

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}