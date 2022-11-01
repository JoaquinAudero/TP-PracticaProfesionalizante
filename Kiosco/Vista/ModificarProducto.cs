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
    public partial class ModificarProducto : Form
    {
        public ModificarProducto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.Show();
            this.Close();
        }
    }
}
