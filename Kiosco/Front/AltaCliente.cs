using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace Front
{
    public partial class AltaCliente : Form
    {
        public AltaCliente()
        {
            InitializeComponent();
        }

        private void buttonAtrás_Click(object sender, EventArgs e)
        {
            CentroDeControl centroDeControl = new CentroDeControl();
            centroDeControl.Show();
            this.Close();
        }
        private void AltaCliente_Load(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            int cantidadClientes = principal.ContarCantidadClientes() + 1;
            txtIdClienteNuevo.Text = cantidadClientes.ToString();
        }

        //Alta Cliente
        private void AltaClienteFront()
        {
            Principal principal = new Principal();
            if (ValidarNombre() == false || ValidarApellido() == false || ValidarDireccion() == false || ValidarTelefono() == false)
            {
                MessageBox.Show("Registro erroneo.");
                return;
            }
            else
            {
                Persona persona = new Persona();
                persona.nombre = txtNombre.Text;
                persona.apellido = txtApellido.Text;
                persona.direccion = txtDireccion.Text;
                persona.telefono = txtTelefono.Text;
                DialogResult result = MessageBox.Show("Esta seguro que quiere registar al cliente:  " + persona.apellido, "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    principal.AltaCliente(persona);
                    LimpiarCampos();
                    MessageBox.Show("Registro exitoso!");
                }
                else
                {
                    MessageBox.Show("Registro erroneo.");
                }
                int cantidadClientes = principal.ContarCantidadClientes() + 1;
                txtIdClienteNuevo.Text = cantidadClientes.ToString();

            }
        }

        //Validar Nombre
        private bool ValidarNombre()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorProvider.SetError(txtNombre, "Debe ingresar un Nombre.");
                return false;
            }
            errorProvider.SetError(txtNombre, "");
            return true;
        }


        //Validar Apellido
        private bool ValidarApellido()
        {
            if(string.IsNullOrEmpty(txtApellido.Text))
            {
                errorProvider.SetError(txtApellido, "Debe ingresar un Apellido.");
                return false;
            }
            errorProvider.SetError(txtApellido, "");
            return true;
        }


        //Validar Direeccion
        private bool ValidarDireccion()
        {
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                errorProvider.SetError(txtDireccion, "Debe ingresar una Dirección.");
                return false;
            }
            errorProvider.SetError(txtDireccion, "");
            return true;
        }


        //Validar Telefono
        private bool ValidarTelefono()
        {
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                errorProvider.SetError(txtTelefono, "Debe ingresar un Teléfono.");
                return false;
            }
            long telefono;
            if (!long.TryParse(txtTelefono.Text, out telefono))
                {
                errorProvider.SetError(txtTelefono, "Debe ingresar un Teléfono correcto.");
                return false;
                }
            errorProvider.SetError(txtTelefono, "");
            return true;
        }


        //Limpiar Campos
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            AltaClienteFront();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AltaClienteFront();
            }
        }

        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AltaClienteFront();
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AltaClienteFront();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AltaClienteFront();
            }
        }
    }
}
