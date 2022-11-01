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
    public partial class AltaDelivery : Form
    {
        public AltaDelivery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery();
            delivery.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AltaDeliveryFront();
        }


        Principal principal = new Principal();


        private void AltaDeliveryFront()
        {
            if (ValidarNombre() == false || ValidarApellido() == false || ValidarDireccion() == false || ValidarTelefono() == false || ValidarDni() == false)
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
                DialogResult result = MessageBox.Show("Esta seguro que quiere registar al Delivery:  " + persona.apellido, "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    principal.AltaDelivery(persona, Convert.ToInt64(txtDni.Text));
                    LimpiarCampos();
                    MessageBox.Show("Registro exitoso!");
                }
                else
                {
                    MessageBox.Show("Registro erroneo.");
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = principal.ListaDeliverys();
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


        //Validar Dni
        public bool ValidarDni()
        {
            if (string.IsNullOrEmpty(txtDni.Text))
            {
                errorProvider.SetError(txtDni, "Debe ingresar un DNI.");
                return false;
            }
            int cantidadNro = txtDni.Text.Length;
            if (!long.TryParse(txtDni.Text, out long dni))
            {
                errorProvider.SetError(txtDni, "Debe ingresar un DNI correcto.");
                return false;
            }
            if (cantidadNro != 8)
            {
                errorProvider.SetError(txtDni, "Debe ingresar un DNI correcto.");
                return false;
            }
            errorProvider.SetError(txtDni, "");
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
            txtDni.Text = "";        
        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AltaDeliveryFront();
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AltaDeliveryFront();
            }
        }

        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AltaDeliveryFront();
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AltaDeliveryFront();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AltaDeliveryFront();
            }
        }

        private void AltaDelivery_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = principal.ListaDeliverys();
        }
    }
}
