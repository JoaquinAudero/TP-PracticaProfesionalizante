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
    public partial class General : Form
    {
        public General()
        {
            InitializeComponent();
        }
        Principal principal = new Principal();
        private void button1_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.Show();
            this.Close();
        }

        private void General_Load(object sender, EventArgs e)
        {
            txtClientesResultado.Text = principal.ContarCantidadClientes().ToString();
            txtDeliveryResultado.Text = principal.ContarCantidadDelivery().ToString();
            txtProveedor.Text = principal.ContarCantidadProveedor().ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery();
            delivery.Show();
            this.Close();
        }
    }
}
