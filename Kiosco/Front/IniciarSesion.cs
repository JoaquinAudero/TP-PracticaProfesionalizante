using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Front
{
    public partial class IniciarSesion : Form
    {
        public IniciarSesion()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }
        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.Black;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }
        //Acceder
        private void AccederAlSistema()
        {
            CentroDeControl centroDeControl = new CentroDeControl();
            centroDeControl.Show();
            this.Hide();
        }
        //Validar Usuario y Contraseña
        private bool ValidarUsuarioContraseña()
        {
            if (txtUsuario.Text == "admin" && txtContraseña.Text == "admin")
            {
                return true;
            }
            if (txtUsuario.Text == "USUARIO" && txtContraseña.Text == "CONTRASEÑA")
            {
                MessageBox.Show("ingrese Usuario y Contraseña");
                return false;
            }
            else
            {       
                MessageBox.Show("Ingesó incorrectamente el Usuario y/o Contraseña");
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarUsuarioContraseña() == true)
            {
                AccederAlSistema();
            }
        }

        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ValidarUsuarioContraseña() == true)
                {
                    AccederAlSistema();
                }
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ValidarUsuarioContraseña() == true)
                {
                    AccederAlSistema();
                }
            }
        }

        private void IniciarSesion_Load(object sender, EventArgs e)
        {
            PersistenciaDatos persistenciaDatos = new PersistenciaDatos();
            persistenciaDatos.InicializarArchivos();
            Principal principal = new Principal();
            principal.RellenarListas();

        }
    }
}
