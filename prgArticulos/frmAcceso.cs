using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;/*Conexion base datos*/
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Llamado de las referencias propias del proyecto
using System.Data.SqlClient;
using Modelo;
using Controlador;

namespace prgArticulos
{
    public partial class frmAcceso : Form
    {
        #region Atributos
        private clsConexionSQL conexion;
        private clsEntidadUsuario pEntidadUsuario;
        private clsUsuario usuario;
        private SqlDataReader dtrUsuario; //Para el retorno de las tuplas
        private int intContador;
        #endregion

        // Inicializamos los atributos que utilizaremos en toda la ventana
        public frmAcceso()
        {
            InitializeComponent();
            conexion = new clsConexionSQL();
            pEntidadUsuario = new clsEntidadUsuario();
            usuario = new clsUsuario();
            intContador = 0;
        }

        private void frmAcceso_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
                //El evento "Focus" permite trasladar el cursor del mouse al objeto indicado
                this.txtClave.Focus();
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                if (txtClave.Text != "" && txtUsuario.Text != "")
                {
                    if (mValidarDatos() == true)
                    {
                        this.btnIngresar.Enabled = true;
                    }
                }
                else
                    MessageBox.Show("Existen campos en blanco", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }//fin KeyPressClave

        #region Metodos Propios

        //Este métoos permite verificar la existencia del usario segun el codigo y la clave
        public Boolean mValidarDatos()
        {
            if (intContador <= 2)
            {
                intContador++;
                //Llenado de los atributos del servidor para conectarme a la base de datos
                conexion.setCodigo("admEstudiante");
                conexion.setClave("123");

                //Llenado de lo atributos de la clase EntidadUsuario
                pEntidadUsuario.setCodigo(this.txtUsuario.Text.Trim());
                pEntidadUsuario.setClave(this.txtClave.Text.Trim());

                //Consltar si el usuario existe
                dtrUsuario = usuario.mConsultarUsuario(conexion, pEntidadUsuario);

                //Evaluar si retorna tuplas o datos
                if (dtrUsuario != null)
                {
                    if (dtrUsuario.Read())
                    {
                        pEntidadUsuario.setPerfil(dtrUsuario.GetString(2));  // |0=codigo|1=clave|2=perfil|
                        pEntidadUsuario.setEstado(dtrUsuario.GetInt32(3));   // No parsear ni cast, INT32 es el recomendado

                        if (pEntidadUsuario.getEstado() == 0)
                        {
                            this.btnIngresar.Enabled = true;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("El usuario esta bloqueado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }//fin del pEntidadUsuario
                    }
                    else {
                        MessageBox.Show("El Usuario no existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }//fin if read
                }
                else
                {
                    MessageBox.Show("El usuario no existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }//fin if null
            }
            else
            {
                MessageBox.Show("usted digitó 3 veces su usuario de forma errónea", "Usuario Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }//fin contador
        }//fin metodo
        #endregion

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Ocultar el formulario actual
            this.SetVisibleCore(false);
            mdiMenu menu = new mdiMenu(conexion);
            menu.Show();
        }
    }//fin de la clase



}//fin namespace

