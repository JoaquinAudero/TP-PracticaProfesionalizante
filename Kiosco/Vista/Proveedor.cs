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
    public partial class Proveedor : Form
    {
        public Proveedor()
        {
            InitializeComponent();
        }


        Principal principal = new Principal();

        private void button2_Click(object sender, EventArgs e)
        {
            AltaProveedor altaProveedor = new AltaProveedor();
            altaProveedor.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow indice in dataGridView1.SelectedRows)
                {
                    int idProveedorEliminado = Convert.ToInt32(indice.Cells[0].Value);
                    DialogResult result = MessageBox.Show("Esta seguro que quiere eliminar al proveedor:  " + indice.Cells[2].Value + "" + indice.Cells[1].Value, "", MessageBoxButtons.YesNo); ;
                    if (result == DialogResult.Yes)
                    {
                        principal.BajaProveedor(idProveedorEliminado);
                        MessageBox.Show("Baja exitosa!");
                    }
                    break;
                }
            }
            else if (dataGridView1.SelectedCells.Count == 1)
            {
                MessageBox.Show("Seleccione la fila entera.");
            }
            else
            {
                MessageBox.Show("Seleccione un solo cliente por vez.");
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = principal.ListaProveedores();
        }

        private void Proveedor_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = principal.ListaProveedores();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModificarProveedor modificarProveedor = new ModificarProveedor();
            if (dataGridView1.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow indice in dataGridView1.SelectedRows)
                {
                    int idClienteModificado = Convert.ToInt32(indice.Cells[0].Value);
                    modificarProveedor.txtIdClienteNuevo.Text = idClienteModificado.ToString();
                    modificarProveedor.txtNombre.Text = indice.Cells[2].Value.ToString();
                    modificarProveedor.txtApellido.Text = indice.Cells[3].Value.ToString();
                    modificarProveedor.txtDireccion.Text = indice.Cells[4].Value.ToString();
                    modificarProveedor.txtTelefono.Text = indice.Cells[5].Value.ToString();
                    modificarProveedor.txtCuil.Text = indice.Cells[1].Value.ToString();
                    break;
                }
                modificarProveedor.Show();
                this.Close();
            }
            else if (dataGridView1.SelectedCells.Count == 1)
            {
                MessageBox.Show("Seleccione la fila entera.");
            }
            else
            {
                MessageBox.Show("Seleccione un solo cliente por vez.");
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = principal.ListaProveedores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            General general = new General();
            general.Show();
            this.Close();
        }

        private void checkBoxFiltrarId_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxFiltrarNombre.Checked = false;
            dataGridView1.DataSource = principal.ListaProveedores();
        }

        private void checkBoxFiltrarNombre_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxFiltrarId.Checked = false;
            dataGridView1.DataSource = principal.ListaProveedoresPorNombre();
        }

        //Validar Busqueda
        public bool ValidarBusqueda()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Debe ingresar una Búsqueda.");
                return false;
            }
            errorProvider1.SetError(textBox1, "");
            return true;
        }


        //Buscar Proveedor
        private void BuscarProveedor()
        {
            if (ValidarBusqueda() == true)
            {
                dataGridView1.DataSource =  principal.BuscarProveedorNombre(textBox1.Text);
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            BuscarProveedor();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarProveedor();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = principal.ListaProveedores();
            textBox1.Text = "";
            checkBoxFiltrarId.Checked = true;
        }
    }
    }

