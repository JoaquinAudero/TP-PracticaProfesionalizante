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
    public partial class Producto : Form
    {
        public Producto()
        {
            InitializeComponent();
        }
        Principal principal = new Principal();

        private void Producto_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = principal.ListaProductos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            General general = new General();
            general.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* AltaProducto altaProducto = new AltaProducto();
            altaProducto.Show();
            this.Close(); */
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
