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
    public partial class mdiMenu : Form
    {
        private clsConexionSQL conexion;

        public mdiMenu(clsConexionSQL conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
        }


        private void mdiMenu_Load(object sender, EventArgs e)
        {

        }

        private void controlDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SetVisibleCore(false);
            frmUsuarios usuarios = new frmUsuarios(conexion);
            usuarios.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
