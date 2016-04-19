using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class clsEntidadUsuario
    {
        #region Atributos
        private string codigo;
        private string clave;
        private string perfil;
        private int estado;
        #endregion

        #region Constructor
        public clsEntidadUsuario()
        {
            this.clave = "";
            this.codigo = "";
            this.perfil = "";
            this.estado = 0;
        }
        #endregion

        //Propiedades de lectura y escritura
        #region Propiedades
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

        public int getEstado()
        {
            return this.estado;
        }

        public void setEstado(int estado)
        {
            this.estado = estado;
        }
        #endregion
    }
}
