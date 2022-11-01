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
    public partial class ClienteGeneral : Form
    {
        public ClienteGeneral()
        {
            InitializeComponent();
        }
        Principal principal = new Principal();

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow indice in dataGridViewClientes.Rows)
            {
                int idClienteEliminado = Convert.ToInt32(indice.Cells[2]);
                principal.BajaCliente(idClienteEliminado);
                dataGridViewClientes.Refresh();
            }
        }

        private void ClienteGeneral_Load(object sender, EventArgs e)
        {
            dataGridViewClientes.DataSource = principal.ListaClientes();
        }
    }
}
