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

namespace Vista
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        //Acceder
        private void AccederAlSistema()
        {
            General general = new General();
            general.Show();
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


        private void IniciarSesion_Load(object sender, EventArgs e)
        {
            Principal principal = new Principal();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave_1(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtContraseña_Enter_1(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.Black;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave_1(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarUsuarioContraseña() == true)
            {
                AccederAlSistema();
            }
        }

        private void txtUsuario_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ValidarUsuarioContraseña() == true)
                {
                    AccederAlSistema();
                }
            }
        }

        private void txtContraseña_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ValidarUsuarioContraseña() == true)
                {
                    AccederAlSistema();
                }
            }
        }
    }
}
