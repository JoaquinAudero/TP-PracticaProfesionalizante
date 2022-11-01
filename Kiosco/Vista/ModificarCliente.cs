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
    public partial class ModificarCliente : Form
    {
        public ModificarCliente()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Show();
            this.Close();
        }
        AltaCliente altaCliente = new AltaCliente();
        Principal principal = new Principal();
        private void ModificarClienteFront()
        {
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
                DialogResult result = MessageBox.Show("Esta seguro que quiere modificar al cliente:  " + persona.apellido, "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    principal.ModificarCliente(Convert.ToInt32(txtIdClienteNuevo.Text), persona);
                    LimpiarCampos();
                    MessageBox.Show("Modificación exitosa!");
                }
                else
                {
                    MessageBox.Show("Falló la modificación.");
                }
                Cliente cliente = new Cliente();
                cliente.Show();
                this.Close();
            }
        }

        //Validar Nombre
        public bool ValidarNombre()
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
        public bool ValidarApellido()
        {
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                errorProvider.SetError(txtApellido, "Debe ingresar un Apellido.");
                return false;
            }
            errorProvider.SetError(txtApellido, "");
            return true;
        }

        //Validar Direeccion
        public bool ValidarDireccion()
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
        public bool ValidarTelefono()
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
        public void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ModificarClienteFront();
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = principal.ListaClientes();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ModificarClienteFront();
            }
        }

        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ModificarClienteFront();
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ModificarClienteFront();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ModificarClienteFront();
            }
        }
    }
}
