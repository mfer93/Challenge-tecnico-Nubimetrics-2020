using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;
using System.Text;

namespace EX1.Models
{
    public class Usuario
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public Usuario()
        {
            this.id = 0;
            this.nombre = "";
            this.apellido = "";
            this.email = "";
            this.password = "";
        }

        public Usuario(long Id, string Nombre, string Apellido, string Email, string Password)
        {
            this.id = Id;
            this.nombre = Nombre;
            this.apellido = Apellido;
            this.email = Email;
            this.password = Password;
        }

        /// <summary>
        /// Consulta los Usuarios cargados en la Tabla User
        /// </summary>
        /// <returns>Lista de objetos Usuario con la Información de los Usuarios</returns>
        public List<Usuario> ObtenerUsuariosDB()
        {
            List<Usuario> usuarios = new List<Usuario>();

            DataSet dsUsuario = Getdb();

            if (dsUsuario != null && dsUsuario.Tables.Count > 0 && dsUsuario.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dataRow in dsUsuario.Tables[0].Rows)
                {
                    Usuario usuario = new Usuario();
                    usuario.id = Convert.ToInt64(dataRow["id"].ToString());
                    usuario.nombre = dataRow["nombre"].ToString();
                    usuario.apellido = dataRow["apellido"].ToString();
                    usuario.email = dataRow["email"].ToString();
                    usuario.password = dataRow["password"].ToString();

                    usuarios.Add(usuario);
                }
            }

            return usuarios;
        }

        public void AltaUsuario()
        {
            if (this.nombre != "" && this.apellido != "" && this.email != "" && this.password != "")
                Insertdb();
        }

        public void ModificaUsuario()
        {
            if (this.id != 0)
            {
                Updatedb();
            }
        }

        public void BajaUsuario()
        {
            if (this.id != 0)
                Deletedb();
        }

        /// <summary>
        /// Consulta la informacion de un Usuario de la Tabla User
        /// </summary>
        /// <param name="id">Si no es null se consulta los datos para el ID especificado</param>
        /// <returns>DataSet con los registros de la consulta</returns>
        DataSet Getdb(long? id = null)
        {
            string szQuery = "SELECT id, nombre, apellido, email, password FROM [User] ";
            if (id != null && id > 0)
                szQuery += "WHERE id=@ID ";

            Database db = new DatabaseProviderFactory().Create("EX1DB");
            DbCommand dbCommand = db.GetSqlStringCommand(szQuery);
            dbCommand.CommandTimeout = 100;
            db.AddInParameter(dbCommand, "ID", DbType.Int64, id ?? 0);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Inserta un registro en la Tabla User median el SP USER_INS
        /// Requiere que el Objeto tenga Nombre, Apellido, Email y Password cargados
        /// </summary>
        void Insertdb()
        {
            string szQuery = "USER_INS";
            Database db = new DatabaseProviderFactory().Create("EX1DB");
            DbCommand dbCommand = db.GetStoredProcCommand(szQuery);
            dbCommand.CommandTimeout = 100;
            db.AddInParameter(dbCommand, "NOMBRE", DbType.String, this.nombre);
            db.AddInParameter(dbCommand, "APELLIDO", DbType.String, this.apellido);
            db.AddInParameter(dbCommand, "EMAIL", DbType.String, this.email);
            db.AddInParameter(dbCommand, "PASSWORD", DbType.String, this.password);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Actualiza un registro en la Tabla User median el SP USER_UPD
        /// Requiere que el Objeto tenga ID, Nombre, Apellido, Email y Password cargados
        /// </summary>
        void Updatedb()
        {
            string szQuery = "USER_UPD";
            Database db = new DatabaseProviderFactory().Create("EX1DB");
            DbCommand dbCommand = db.GetStoredProcCommand(szQuery);
            dbCommand.CommandTimeout = 100;
            db.AddInParameter(dbCommand, "ID", DbType.Int64, this.id);
            db.AddInParameter(dbCommand, "NOMBRE", DbType.String, this.nombre);
            db.AddInParameter(dbCommand, "APELLIDO", DbType.String, this.apellido);
            db.AddInParameter(dbCommand, "EMAIL", DbType.String, this.email);
            db.AddInParameter(dbCommand, "PASSWORD", DbType.String, this.password);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Elimina un registro en la Tabla User median el SP USER_DEL
        /// Requiere que el Objeto tenga ID, Nombre, Apellido, Email y Password cargados
        /// </summary>
        void Deletedb()
        {
            string szQuery = "USER_DEL";
            Database db = new DatabaseProviderFactory().Create("EX1DB");
            DbCommand dbCommand = db.GetStoredProcCommand(szQuery);
            dbCommand.CommandTimeout = 100;
            db.AddInParameter(dbCommand, "ID", DbType.Int64, this.id);
            db.ExecuteNonQuery(dbCommand);
        }

    }

    /// <summary>
    /// Clase para Encriptar y Desencriptar en MD5
    /// </summary>
    public class MD5
    {
        public string Encrypt(string text)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(text));

            StringBuilder sBuilder = new StringBuilder();
            int m_i;

            for (m_i = 0; m_i <= data.Length - 1; m_i++)
                sBuilder.Append(data[m_i].ToString("x2")); //Hexadecimal

            return sBuilder.ToString();
        }
    }
}