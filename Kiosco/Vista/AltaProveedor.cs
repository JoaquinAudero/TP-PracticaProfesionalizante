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
    public partial class AltaProveedor : Form
    {
        public AltaProveedor()
        {
            InitializeComponent();
        }

        Principal principal = new Principal();

        private void button1_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.Show();
            this.Close();
        }

        private void AltaProveedorFront()
        {
            if (ValidarNombre() == false || ValidarApellido() == false || ValidarDireccion() == false || ValidarTelefono() == false || ValidarCuil() == false)
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
                DialogResult result = MessageBox.Show("Esta seguro que quiere registar al Proveedor:  " + persona.apellido, "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    principal.AltaProveedor(persona, Convert.ToInt64(txtCuil.Text));
                    LimpiarCampos();
                    MessageBox.Show("Registro exitoso!");
                }
                else
                {
                    MessageBox.Show("Registro erroneo.");
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = principal.ListaProveedores();
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


        //Validar Cuil
        public bool ValidarCuil()
        {
            if (string.IsNullOrEmpty(txtCuil.Text))
            {
                errorProvider.SetError(txtCuil, "Debe ingresar un CUIL sin separación.");
                return false;
            }
            int cantidadNro = txtCuil.Text.Length;
            if (!long.TryParse(txtCuil.Text, out long dni))
            {
                errorProvider.SetError(txtCuil, "Debe ingresar un CUIL correcto, sin separación.");
                return false;
            }
            if (cantidadNro != 11)
            {
                errorProvider.SetError(txtCuil, "Debe ingresar un CUIL correcto, sin separación.");
                return false;
            }
            errorProvider.SetError(txtCuil, "");
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

            if (!long.TryParse(txtTelefono.Text, out long telefono))
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
            txtCuil.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AltaProveedorFront();
        }

        private void AltaProveedor_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = principal.ListaProveedores();
        }

        private void txtCuil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AltaProveedorFront();
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AltaProveedorFront();
            }
        }

        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AltaProveedorFront();
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AltaProveedorFront();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AltaProveedorFront();
            }
        }
    }
}
