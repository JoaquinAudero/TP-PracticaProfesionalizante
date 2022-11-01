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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Vista
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }


        Principal principal = new Principal();


        private void button2_Click(object sender, EventArgs e)
        {
            AltaCliente altaCliente = new AltaCliente();
            altaCliente.Show();
            this.Close();
        }


        private void Cliente_Load(object sender, EventArgs e)
        {
            checkBoxApellido.Checked = false;
            checkBoxFiltrarNombre.Checked = false;
            checkBoxFiltrarId.Checked = true;
            dataGridView1.DataSource = principal.ListaClientes();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow indice in dataGridView1.SelectedRows)
                {
                    int idClienteEliminado = Convert.ToInt32(indice.Cells[0].Value);
                    DialogResult result = MessageBox.Show("Esta seguro que quiere eliminar al cliente:  " + indice.Cells[2].Value + "" + indice.Cells[1].Value, "", MessageBoxButtons.YesNo); ;
                    if (result == DialogResult.Yes)
                    {
                        principal.BajaCliente(idClienteEliminado);
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
            dataGridView1.DataSource = principal.ListaClientes();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            ModificarCliente modificarCliente = new ModificarCliente();
            if (dataGridView1.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow indice in dataGridView1.SelectedRows)
                {
                    int idClienteModificado = Convert.ToInt32(indice.Cells[0].Value);
                    modificarCliente.txtIdClienteNuevo.Text = idClienteModificado.ToString();
                    modificarCliente.txtNombre.Text = indice.Cells[1].Value.ToString();
                    modificarCliente.txtApellido.Text = indice.Cells[2].Value.ToString();
                    modificarCliente.txtDireccion.Text = indice.Cells[3].Value.ToString();
                    modificarCliente.txtTelefono.Text = indice.Cells[4].Value.ToString();
                    break;
                }
                modificarCliente.Show();
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
            dataGridView1.DataSource = principal.ListaClientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            General general = new General();
            general.Show();
            this.Close();
        }
        //Filtrar datagridview
        private void checkBoxFiltroApellido_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxFiltrarNombre.Checked = false;
            checkBoxFiltrarId.Checked = false;
            dataGridView1.DataSource = principal.ListaClientesPorApellido();
        }

        private void checkBoxFiltrarNombre_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxFiltroApellido.Checked = false;
            checkBoxFiltrarId.Checked = false;
            dataGridView1.DataSource = principal.ListaClientesPorNombre();
        }

        private void checkBoxFiltrarId_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxFiltroApellido.Checked = false;
            checkBoxFiltrarNombre.Checked = false;
            dataGridView1.DataSource = principal.ListaClientes();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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


        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = principal.ListaClientes();
            textBox1.Text = "";
            checkBoxApellido.Checked = false;
            checkBoxNombre.Checked = false;
            checkBoxFiltrarId.Checked = true;
        }

        private void BuscarCliente()
        {
            if (ValidarBusqueda() == true)
            {
                if (checkBoxNombre.Checked == true && checkBoxApellido.Checked == false)
                {
                    dataGridView1.DataSource = principal.BuscarClienteNombre(textBox1.Text);
                }
                if (checkBoxApellido.Checked == true && checkBoxNombre.Checked == false)
                {
                    dataGridView1.DataSource = principal.BuscarClienteApellido(textBox1.Text);
                }
                if (checkBoxNombre.Checked == false && checkBoxApellido.Checked == false)
                {
                    dataGridView1.DataSource = principal.ListaClientes();
                    MessageBox.Show("Solo marque una casilla.");
                }
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarCliente();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void checkBoxApellido_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxNombre.Checked = false;
            textBox1.Text = "";
        }

        private void checkBoxNombre_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxApellido.Checked = false;
            textBox1.Text = "";
        }
    }
}

