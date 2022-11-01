using Logica;
using System;
using System.Windows.Forms;

namespace Front
{
    public partial class CentroDeControl : Form
    {
        public CentroDeControl()
        {
            InitializeComponent();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IniciarSesion iniciarSesion = new IniciarSesion();
            iniciarSesion.Show();
            this.Close();
        }

        Principal principal = new Principal();
        PersistenciaDatos persistenciaDatos = new PersistenciaDatos();
        private void CentroDeControl_Load(object sender, EventArgs e)
        {
            persistenciaDatos.InicializarArchivos();
            principal.RellenarListas();
            txtClientesResultado.Text = principal.ContarCantidadClientes().ToString();
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClienteGeneral clienteGeneral = new ClienteGeneral();
            clienteGeneral.Show();
            this.Close();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaCliente altaCliente = new AltaCliente();
            altaCliente.Show();
            this.Close();

        }

        private void altaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AltaProveedor altaProveedor = new AltaProveedor();
            altaProveedor.Show();
            this.Close();
        }

        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AltaProducto altaProducto = new AltaProducto();
            altaProducto.Show();
            this.Close();
        }
    }
}
