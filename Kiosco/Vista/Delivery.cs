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
    public partial class Delivery : Form
    {
        public Delivery()
        {
            InitializeComponent();
        }


        Principal principal = new Principal();


        private void Delivery_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = principal.ListaDeliverys();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            General general = new General();
            general.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AltaDelivery altaDelivery = new AltaDelivery();
            altaDelivery.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModificarDelivery modificarDelivery = new ModificarDelivery();
            if (dataGridView1.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow indice in dataGridView1.SelectedRows)
                {
                    int idDeliveryModificado = Convert.ToInt32(indice.Cells[0].Value);
                    modificarDelivery.txtIdClienteNuevo.Text = idDeliveryModificado.ToString();
                    modificarDelivery.txtDni.Text = indice .Cells[1].Value.ToString();
                    modificarDelivery.txtNombre.Text = indice.Cells[2].Value.ToString();
                    modificarDelivery.txtApellido.Text = indice.Cells[3].Value.ToString();
                    modificarDelivery.txtDireccion.Text = indice.Cells[4].Value.ToString();
                    modificarDelivery.txtTelefono.Text = indice.Cells[5].Value.ToString();
                    break;
                }
                modificarDelivery.Show();
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
            dataGridView1.DataSource = principal.ListaDeliverys();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow indice in dataGridView1.SelectedRows)
                {
                    int idDeliveryEliminado = Convert.ToInt32(indice.Cells[0].Value);
                    DialogResult result = MessageBox.Show("Esta seguro que quiere eliminar al delivery:  " + indice.Cells[2].Value, "", MessageBoxButtons.YesNo); ;
                    if (result == DialogResult.Yes)
                    {
                        principal.BajaDelivery(idDeliveryEliminado);
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
            dataGridView1.DataSource = principal.ListaDeliverys();
        }
    }
}
