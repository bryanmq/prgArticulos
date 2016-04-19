using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; //Retornar del system de windows el nombre de la máquina
using System.Data.SqlClient; //Accesos a la BD(IMEC)

namespace Modelo
{
    public class clsConexionSQL
    {
        //Área de la declaración de todas las variables.
        #region Atributos
        private string codigo;
        private string clave;
        private string perfil;
        private string baseDatos;

        private SqlConnection conexion; //Guarda la cadena de conexión del usario con la BD.
        private SqlCommand comando; //permite ejecutar los IMEC
        #endregion

        //Establecemos el método inicial
        #region Construtor
        public clsConexionSQL()
        {
            this.codigo = "";
            this.clave = "";
            this.perfil = "";
            this.baseDatos = "BDEstudiantes";
        }
        #endregion

        //Propiedades de lectura y escritura
        #region GetySet
        public void setCodigo(string codigo)
        {
            this.codigo = codigo.Trim();
        }

        public String getCodigo()
        {
            return this.codigo;
        }

        public void setClave(string clave)
        {
            this.clave = clave.Trim();
        }

        public String getClave()
        {
            return this.clave;
        }

        public void setPerfil(string perfil)
        {
            this.perfil = perfil.Trim();
        }

        public String getPerfil()
        {
            return this.perfil;
        }
        #endregion

        //Métodos para la conexión a la BD
        #region Metodos

        //Este Método permitirá ejecutar los selects
        public SqlDataReader mSeleccionar(string strSentencia, clsConexionSQL cone)
        {
            try
            {
                if (mConectar(cone))
                {
                    comando = new SqlCommand(strSentencia, conexion);
                    comando.CommandType = System.Data.CommandType.Text;
                    return comando.ExecuteReader(); //permite ejecutar solo el select
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Este método permitirá ejecutar los Insert, Update y Delete
        public Boolean mEjecutar(string strSentencia, clsConexionSQL cone)
        {
            try
            {
                if (mConectar(cone))
                {
                    comando = new SqlCommand(strSentencia, conexion);
                    comando.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        //Este metodo nos permite abrir y conectarnos a la BD
        public Boolean mConectar(clsConexionSQL cone)
        {
            try
            {
                conexion = new SqlConnection(); //Ingresa mediante System.Data.SqlClient
                conexion.ConnectionString = "user id='" + cone.getCodigo() + "'; password='" + cone.getClave() + "'; Data Source='" + mNomServidor() + "'; Initial Catalog='" + this.baseDatos + "'";
                conexion.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Obtiene el nombre de la máquina de Windows
        public String mNomServidor()
        {
            return Dns.GetHostName(); //System.Net
        }
        #endregion
    }
}