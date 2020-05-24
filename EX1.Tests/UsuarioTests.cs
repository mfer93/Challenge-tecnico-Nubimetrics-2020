using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EX1.Models;
using System.Collections.Generic;
using System.Linq;

namespace EX1.Tests
{
    [TestClass]
    public class UsuarioTests
    {
        /// <summary>
        /// Chequear que se obtengan todos los Usuarios de la BD de forma correcta
        /// </summary>
        [TestMethod]
        public void TestGetbd()
        {
            //Arrange
            List<Usuario> UsuariosTestTrue = new List<Usuario>(); //Para los mismos usuarios que el Script SQL
            List<Usuario> UsuariosTestFalse = new List<Usuario>();//Para Usuarios diferentes del Script SQL
            List<Usuario> UsuariosDB = new List<Usuario>();//Para los Usuarios de la BD (cargados solo a traves del Script)

            //Action
            UsuariosTestTrue = UsuariosPruebaTrue();
            UsuariosTestFalse = UsuariosPruebaFalse();
            UsuariosDB = new Usuario().ObtenerUsuariosDB();

            //Assert
            Assert.IsTrue(UsuariosTestTrue.SequenceEqual(UsuariosDB, new UserEqualityComparer())); //La listas deberian ser iguales
            Assert.IsFalse(UsuariosTestFalse.SequenceEqual(UsuariosDB, new UserEqualityComparer())); //Las listas deberian ser distintias
        }

        /// <summary>
        /// Chequear que la Obtencion del HashMD5 sea correcta
        /// </summary>
        [TestMethod]
        public void TestEncrypt()
        {
            //Arrange 
            string md5HashResult = "827ccb0eea8a706c4c34a16891f84e7b"; //Calculado de https://www.md5hashgenerator.com/
            string text = "12345"; //Texto a convertir
            string md5Hash = "";

            //Action
            md5Hash = new MD5().Encrypt(text);

            //Assert
            Assert.AreEqual(md5HashResult, md5Hash); //El Hash deberia ser el mismo

        }

        /// <summary>
        /// Lista de Usuarios con los mismos datos del Script SQL de Prueba
        /// </summary>
        /// <returns></returns>
        public List<Usuario> UsuariosPruebaTrue()
        {
            return new List<Usuario>(){
                new Usuario(1, "VICTOR", "CALDERON", "VICDERON@HOTMAIL.COM", "vic12345"),
                new Usuario(2, "JESSIE", "FADEN", "JFADEN@LIVE.COM", "JF555"),
                new Usuario(3, "JONH", "SMITH", "SMITH37@GMAIL.COM", "PF51015"),
                new Usuario(4, "FRANK", "WATTERSON", "FRANKIEW@HOTMAIL.COM", "FW303"),
                new Usuario(5, "DYLAN", "SMITH", "DSMITH@LIVE.COM", "DL5485")};
        }

        /// <summary>
        /// Lista de Usuarios con el Primer Usuario diferente al Script SQL de Prueba
        /// </summary>
        /// <returns></returns>
        public List<Usuario> UsuariosPruebaFalse()
        {
            return new List<Usuario>(){
                new Usuario(1, "OSCAR", "VALDERRAMA", "VALDE993@HOTMAIL.COM", "oscarderrama456"),
                new Usuario(2, "JESSIE", "FADEN", "JFADEN@LIVE.COM", "JF555"),
                new Usuario(3, "JONH", "SMITH", "SMITH37@GMAIL.COM", "PF51015"),
                new Usuario(4, "FRANK", "WATTERSON", "FRANKIEW@HOTMAIL.COM", "FW303"),
                new Usuario(5, "DYLAN", "SMITH", "DSMITH@LIVE.COM", "DL5485")};
        }

    }

    /// <summary>
    /// Reescritura del Comparador para Usuario
    /// </summary>
    public class UserEqualityComparer : IEqualityComparer<Usuario>
    {
        public bool Equals(Usuario x, Usuario y)
        {
            if (object.ReferenceEquals(x, y)) return true;

            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false;

            return x.id == y.id && x.nombre == y.nombre && x.apellido == y.apellido && x.email == y.email && x.password == y.password;
        }

        public int GetHashCode(Usuario obj)
        {
            if (object.ReferenceEquals(obj, null)) return 0;

            int hashCodeId = obj.id.GetHashCode();
            int hashCodeName = obj.nombre.GetHashCode();
            int hashCodeLastName = obj.nombre.GetHashCode();
            int hashCodeMail = obj.nombre.GetHashCode();
            int hashCodePassword = obj.nombre.GetHashCode();

            return hashCodeId ^ hashCodeName ^ hashCodeLastName ^ hashCodeMail ^ hashCodePassword;
        }
    }
}

