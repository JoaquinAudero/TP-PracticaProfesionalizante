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
    public partial class AltaProducto : Form
    {
        public AltaProducto()
        {
            InitializeComponent();
        }

        private void buttonAtrás_Click(object sender, EventArgs e)
        {
            CentroDeControl centroDeControl = new CentroDeControl();
            centroDeControl.Show();
            this.Close();
        }
    }
}
