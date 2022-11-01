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
    public partial class AltaProveedor : Form
    {
        public AltaProveedor()
        {
            InitializeComponent();
        }

        private void buttonAtrás_Click(object sender, EventArgs e)
        {
            CentroDeControl centroDeControl = new CentroDeControl();
            centroDeControl.Show();
            this.Close();
        }
        Principal principal = new Principal();

        private void AltaProveedor_Load(object sender, EventArgs e)
        {
            PersistenciaDatos persistenciaDatos = new PersistenciaDatos();
            persistenciaDatos.InicializarArchivos();
            Principal principal = new Principal();
            principal.RellenarListas();
            int cantidadProveedor = principal.ContarCantidadProveedor() + 1;
            txtIdProveedorNuevo.Text = cantidadProveedor.ToString();
        }

        //Alta Proveedor

        private void AltaProveedorFront()
        {
            if (ValidarNombre() == false || ValidarApellido() == false || ValidarDireccion() == false || ValidarTelefono() == false || ValidarCuil () == false)
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
                long cuil = Convert.ToInt64(txtCuil.Text);
                DialogResult result = MessageBox.Show("Esta seguro que quiere registar al cliente" + persona.apellido, "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    principal.AltaProveedor(persona, cuil);
                    LimpiarCampos();
                    MessageBox.Show("Registro exitoso!");
                }
                else
                {
                    MessageBox.Show("Registro erroneo.");
                }
                int cantidadProveedor = principal.ContarCantidadProveedor() + 1;
                txtIdProveedorNuevo.Text = cantidadProveedor.ToString();

            }
        }


            //Validar Nombre
            private bool ValidarNombre()
            {
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    errorProvider1.SetError(txtNombre, "Debe ingresar un Nombre.");
                    return false;
                }
                errorProvider1.SetError(txtNombre, "");
                return true;
            }


            //Validar Apellido
            private bool ValidarApellido()
            {
                if (string.IsNullOrEmpty(txtApellido.Text))
                {
                    errorProvider1.SetError(txtApellido, "Debe ingresar un Apellido.");
                    return false;
                }
                errorProvider1.SetError(txtApellido, "");
                return true;
            }


            //Validar Direeccion
            private bool ValidarDireccion()
            {
                if (string.IsNullOrEmpty(txtDireccion.Text))
                {
                    errorProvider1.SetError(txtDireccion, "Debe ingresar una Dirección.");
                    return false;
                }
                errorProvider1.SetError(txtDireccion, "");
                return true;
            }


            //Validar Telefono
            private bool ValidarTelefono()
            {
                if (string.IsNullOrEmpty(txtTelefono.Text))
                {
                    errorProvider1.SetError(txtTelefono, "Debe ingresar un Teléfono.");
                    return false;
                }
                long telefono;
                if (!long.TryParse(txtTelefono.Text, out telefono))
                {
                    errorProvider1.SetError(txtTelefono, "Debe ingresar un Teléfono correcto.");
                    return false;
                }
                errorProvider1.SetError(txtTelefono, "");
                return true;
            }


            //Validar Cuil
            private bool ValidarCuil()
            {
                if (string.IsNullOrEmpty(txtCuil.Text))
                {
                    errorProvider1.SetError(txtCuil, "Debe ingresar un Cuil.");
                    return false;
                }
                long telefono;
                if (!long.TryParse(txtCuil.Text, out telefono))
                {
                    errorProvider1.SetError(txtCuil, "Debe ingresar un Cuil correcto.");
                    return false;
                }
                errorProvider1.SetError(txtCuil, "");
                return true;
            }

            //Limpiar Campos
            private void LimpiarCampos()
                {
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtDireccion.Text = "";
                    txtTelefono.Text = "";
                    txtCuil.Text = "";
                }

        private void button3_Click(object sender, EventArgs e)
        {
            AltaProveedorFront();
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

        private void txtCuil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AltaProveedorFront();
            }
        }
    }
}

