using System;

namespace Logica
{
    public class Pedido
    {
        public int idPedido { get; set; }
        public DateTime fechaHora { get; set; }
        public int precioTotalPedido { get; set; }
        public int cantidadProductoPedido { get; set; }
        public Cliente clientePedido { get; set; }
        public Delivery deiveryPedido { get; set; }
    }
}
