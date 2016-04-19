using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;

namespace prgArticulos
{
    public partial class frmUsuarios : Form
    {
        private clsConexionSQL conexion;
        public frmUsuarios(clsConexionSQL conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
            mdiMenu mdi = new mdiMenu(conexion);
            mdi.ShowDialog();
        }
    }
}
