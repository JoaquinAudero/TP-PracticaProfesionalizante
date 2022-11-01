using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Logica
{
    public class Principal
    {


        //Relleno De Listas
        readonly PersistenciaDatos InstanciaPersistenciaDatos = new PersistenciaDatos();
        public void RellenarListas()
        {
            ListaCliente = InstanciaPersistenciaDatos.LeerArchivoCliente();
            ListaClienteEliminado = InstanciaPersistenciaDatos.LeerArchivoClienteEliminado();

            ListaDelivery = InstanciaPersistenciaDatos.LeerArchivoDelivery();
            ListaDeliveryEliminado = InstanciaPersistenciaDatos.LeerArchivoDeliveryEliminado();

            ListaProveedor = InstanciaPersistenciaDatos.LeerArchivoProveedor();
            ListaProveedorEliminado = InstanciaPersistenciaDatos.LeerArchivoProveedorEliminado();

            ListaProducto = InstanciaPersistenciaDatos.LeerArchivoProducto();
            ListaProductoEliminado = InstanciaPersistenciaDatos.LeerArchivoProductoEliminado();
        }


        public Principal ()
        {
            PersistenciaDatos persistenciaDatos = new PersistenciaDatos();
            persistenciaDatos.InicializarArchivos();
            RellenarListas();
        }
        
    

        //Alta Cliente
        List<Cliente> ListaCliente = new List<Cliente>();
        List<int> ListaClienteEliminado = new List<int>();
        public void AltaCliente(Persona personaNueva)
        {
            Cliente nuevoCliente = new Cliente();
            ListaCliente = ValidarCliente();
            ListaClienteEliminado = ValidarClienteEliminado();
            if (ListaClienteEliminado.Count() == 0)
            {
                int idnuevo = ListaCliente.Count();
                idnuevo ++;
                nuevoCliente.idCliente = idnuevo;
            }
            else
            {
                ListaClienteEliminado.Sort();
                int idnuevo = ListaClienteEliminado[0];
                nuevoCliente.idCliente = idnuevo;
                ListaClienteEliminado.Remove(idnuevo);
            }
            nuevoCliente.nombre = personaNueva.nombre;
            nuevoCliente.apellido = personaNueva.apellido;
            nuevoCliente.direccion = personaNueva.direccion;
            nuevoCliente.telefono = personaNueva.telefono;
            ListaCliente.Add(nuevoCliente);
            InstanciaPersistenciaDatos.GuardarArchivoCliente(ListaCliente);
            InstanciaPersistenciaDatos.GuardarArchivoClienteEliminado(ListaClienteEliminado);
        }


        //Baja Cliente
        public void BajaCliente(int idCliente)
        {
            ListaClienteEliminado = ValidarClienteEliminado();
            var cienteEliminado = ListaCliente.Find(x => idCliente == x.idCliente);
            ListaClienteEliminado.Add(idCliente);
            ListaCliente.Remove(cienteEliminado);
            InstanciaPersistenciaDatos.GuardarArchivoCliente(ListaCliente);
            InstanciaPersistenciaDatos.GuardarArchivoClienteEliminado(ListaClienteEliminado);
        }


        //Modificacion Cliente
        public void ModificarCliente(int idCliente, Persona personaNueva)
        {
            var clienteModificado = ListaCliente.Find(x => idCliente == x.idCliente);
            clienteModificado.nombre = personaNueva.nombre;
            clienteModificado.apellido = personaNueva.apellido;
            clienteModificado.direccion = personaNueva.direccion;
            clienteModificado.telefono = personaNueva.telefono;
            var clienteEliminado = ListaCliente.Find(x => idCliente == x.idCliente);
            ListaCliente.Remove(clienteEliminado);
            ListaCliente.Add(clienteModificado);
            InstanciaPersistenciaDatos.GuardarArchivoCliente(ListaCliente);
        }


        //Validar Cliente
        public List<Cliente> ValidarCliente()
        {
            ListaCliente= InstanciaPersistenciaDatos.LeerArchivoCliente();
            if (ListaCliente== null)
            {
                List<Cliente> nuevaListaClienteDelivery = new List<Cliente>();
                return nuevaListaClienteDelivery;
            }
            return ListaCliente;
        }


        //Validar Cliente Eliminado
        public List<int> ValidarClienteEliminado()
        {
            ListaClienteEliminado = InstanciaPersistenciaDatos.LeerArchivoClienteEliminado();
            if (ListaClienteEliminado == null)
            {
                List<int> nuevaListaClienteEliminado = new List<int>();
                return nuevaListaClienteEliminado;
            }
            return ListaClienteEliminado;
        }


        //Cuenta Cantidad de Clientes
        public int ContarCantidadClientes()
        {
            if (ListaCliente == null)
            {
                return 0;
            }
            return ListaCliente.Count();
        }


        //Cuenta Cantidad de Clientes Eliminados
        public int ContarCantidadClientesEliminado()
        {
            if (ListaClienteEliminado == null)
            {
                return 0;
            }
            return ListaClienteEliminado.Count();
        }


        //Lista Clientes ordenada por ID
        public List<Cliente> ListaClientes()
        {
            ListaCliente = ValidarCliente();
            if (ListaCliente.Count < 2)
            {
                return ValidarCliente();
            }
            ListaCliente.Sort(delegate (Cliente x, Cliente y)
                    {
                        return x.idCliente.CompareTo(y.idCliente);
                    });
            return ListaCliente;
        }

        //Lista Clientes ordenada por Apellido
        public List<Cliente> ListaClientesPorApellido()
        {
            ListaCliente = ValidarCliente();
            if (ListaCliente.Count < 2)
            {
                return ValidarCliente();
            }
            ListaCliente.Sort(delegate (Cliente x, Cliente y)
            {
                return x.apellido.CompareTo(y.apellido);
            });
            return ListaCliente;
        }

        //Lista Clientes ordenadas por Nombre
        public List<Cliente> ListaClientesPorNombre()
        {
            ListaCliente = ValidarCliente();
            if (ListaCliente.Count < 2)
            {
                return ValidarCliente();
            }
            ListaCliente.Sort(delegate (Cliente x, Cliente y)
            {
                return x.nombre.CompareTo(y.nombre);
            });
            return ListaCliente;
        }

        //Lista Clientes Eliminado
        public List<int> ListaClientesEliminado()
        {
            ListaClienteEliminado.Sort();
            return ListaClienteEliminado;
        }


        //Buscar Cliente Id
        public List<Cliente> BuscarClienteId(int idCliente)
        {

            List<Cliente> nuevaListaCliente = new List<Cliente>();
            if (ListaCliente == null)
            {
                return nuevaListaCliente;
            }
            else
            {
                var clienteObtenido = ListaCliente.Find(x => idCliente == x.idCliente);
                nuevaListaCliente.Add(clienteObtenido);
                nuevaListaCliente.Sort(delegate (Cliente x, Cliente y)
                {
                    return x.idCliente.CompareTo(y.idCliente);
                });
                return nuevaListaCliente;
            }
        }


        //Buscar Cliente Apellido
        public List<Cliente> BuscarClienteApellido (string apellidoCliente)
        {
            ListaCliente = ValidarCliente();
            List<Cliente> nuevaListaCliente = new List<Cliente>();
            foreach (var cliente in ListaCliente)
            {
                if (cliente.apellido.ToString().ToLower().Contains(apellidoCliente.ToLower())) 
                {
                    nuevaListaCliente.Add(cliente);              
                }
            }
            nuevaListaCliente.Sort(delegate (Cliente x, Cliente y)
            {
                return x.apellido.CompareTo(y.apellido);
            });
            return nuevaListaCliente;
        }


        //Buscar Cliente Nombre
        public List<Cliente> BuscarClienteNombre(string nombreCliente)
        {
            ListaCliente = ValidarCliente();
            List<Cliente> nuevaListaCliente = new List<Cliente>();
            foreach (var cliente in ListaCliente)
            {
                if (cliente.nombre.ToString().ToLower().Contains(nombreCliente.ToLower())) 
                {
                    nuevaListaCliente.Add(cliente);
                }

            }
            nuevaListaCliente.Sort(delegate (Cliente x, Cliente y)
            {
                return x.nombre.CompareTo(y.nombre);
            });
            return nuevaListaCliente;
        }


        //Alta Delivery
        List<Delivery> ListaDelivery = new List<Delivery>();
        List<int> ListaDeliveryEliminado = new List<int>();

        public void AltaDelivery(Persona personaNueva, long dniNuevo)
        {
            Delivery nuevoDelivery = new Delivery();
            ListaDelivery = ValidarDelivery();
            ListaDeliveryEliminado = ValidarDeliveryEliminado();
            if (ListaDeliveryEliminado.Count() == 0)
            {
                int idnuevo = ListaDelivery.Count();
                idnuevo++;
                nuevoDelivery.idDelivery = idnuevo;
            }
            else
            {
                ListaDeliveryEliminado.Sort();
                int idnuevo = ListaDeliveryEliminado[0];
                nuevoDelivery.idDelivery = idnuevo;
                ListaDeliveryEliminado.Remove(idnuevo);
            }
            nuevoDelivery.nombre = personaNueva.nombre;
            nuevoDelivery.apellido = personaNueva.apellido;
            nuevoDelivery.direccion = personaNueva.direccion;
            nuevoDelivery.telefono = personaNueva.telefono;
            nuevoDelivery.dni = dniNuevo;
            ListaDelivery.Add(nuevoDelivery);
            InstanciaPersistenciaDatos.GuardarArchivoDelivery(ListaDelivery);
            InstanciaPersistenciaDatos.GuardarArchivoDeliveryEliminado(ListaDeliveryEliminado);
        }


        //Baja Delivery
        public void BajaDelivery(int idDelivery)
        {
            var deliveryEliminado = ListaDelivery.Find(x => idDelivery == x.idDelivery);
            ListaDeliveryEliminado.Add(idDelivery);
            ListaDelivery.Remove(deliveryEliminado);
            InstanciaPersistenciaDatos.GuardarArchivoDelivery(ListaDelivery);
            InstanciaPersistenciaDatos.GuardarArchivoDeliveryEliminado(ListaDeliveryEliminado);
        }


        //Modificacion Delivery
        public void ModificarDelivery(int idDelivery, Persona deliveryNuevo, long dniNuevo)
        {
            var deliveryModificado = ListaDelivery.Find(x => idDelivery == x.idDelivery);
            deliveryModificado.idDelivery = idDelivery;
            deliveryModificado.nombre = deliveryNuevo.nombre;
            deliveryModificado.apellido = deliveryNuevo.apellido;
            deliveryModificado.direccion = deliveryNuevo.direccion;
            deliveryModificado.telefono = deliveryNuevo.telefono;
            deliveryModificado.dni = dniNuevo;
            var deliveryEliminado = ListaDelivery.Find(x => idDelivery == x.idDelivery);
            ListaDelivery.Remove(deliveryEliminado);
            ListaDelivery.Add(deliveryModificado);
            InstanciaPersistenciaDatos.GuardarArchivoDelivery(ListaDelivery);
        }


        //Validar Delivery
        public List<Delivery> ValidarDelivery()
        {
            ListaDelivery = InstanciaPersistenciaDatos.LeerArchivoDelivery();
            if (ListaDelivery == null)
            {
                List<Delivery> nuevaListaDelivery = new List<Delivery>();
                return nuevaListaDelivery;
            }
            return ListaDelivery;
        }


        //Validar Delivery Eliminado
        public List<int> ValidarDeliveryEliminado()
        {
            ListaDeliveryEliminado = InstanciaPersistenciaDatos.LeerArchivoDeliveryEliminado();
            if (ListaDeliveryEliminado == null)
            {
                List<int> nuevaListaDeliveryEliminado = new List<int>();
                return nuevaListaDeliveryEliminado;
            }
            return ListaDeliveryEliminado;
        }


        //Cuenta Cantidad de Delivery
        public int ContarCantidadDelivery()
        {
            if (ListaDelivery == null)
            {
                return 0;
            }
            return ListaDelivery.Count;
        }


        //Lista Delivery
        public List<Delivery> ListaDeliverys()
        {
            ListaDelivery =  ValidarDelivery();
            if (ListaDelivery.Count < 2)
            {
                return ValidarDelivery();
            }
            ListaDelivery.Sort(delegate (Delivery x, Delivery y)
            {
                return x.idDelivery.CompareTo(y.idDelivery);
            });
            return ListaDelivery;
        }


        //Buscar Delivery Id
        public List<Delivery> BuscarDeliveryId(int idDelivery)
        {

            List<Delivery> nuevaListaDelivery = new List<Delivery>();
            if (ListaDelivery == null)
            {
                return nuevaListaDelivery;
            }
            else
            {
                var deliveryObtenido = ListaDelivery.Find(x => idDelivery == x.idDelivery);
                nuevaListaDelivery.Add(deliveryObtenido);
                return nuevaListaDelivery;
            }
        }


        //Buscar Delivery Apellido
        public List<Delivery> BuscarDeliveryApellido(string apellidoDeliery)
        {
            List<Delivery> nuevaListaDelivery = new List<Delivery>();
            if (ListaDelivery == null)
            {
                return nuevaListaDelivery;
            }
            else
            {
                var deliveryObtenido = ListaDelivery.Find(x => apellidoDeliery == x.apellido);
                return nuevaListaDelivery;
            }
        }


        //Alta Proveedor
        List<Proveedor> ListaProveedor = new List<Proveedor>();
        List<int> ListaProveedorEliminado = new List<int>();
        public void AltaProveedor(Persona personaNueva, long cuilNuevo)
        {
            Proveedor nuevoProveedor = new Proveedor();
            ListaProveedor = ValidarProveedor();
            ListaProveedorEliminado = ValidarProveedorEliminado();
            if (ListaProveedorEliminado.Count() == 0)
            {
                int idnuevo = ListaProveedor.Count();
                idnuevo++;
                nuevoProveedor.idProveedor = idnuevo;
            }
            else
            {
                ListaProveedorEliminado.Sort();
                int idnuevo = ListaProveedorEliminado[0];
                nuevoProveedor.idProveedor = idnuevo;
                ListaProveedorEliminado.Remove(idnuevo);
            }
            nuevoProveedor.nombre = personaNueva.nombre;
            nuevoProveedor.apellido = personaNueva.apellido;
            nuevoProveedor.direccion = personaNueva.direccion;
            nuevoProveedor.telefono = personaNueva.telefono;
            nuevoProveedor.cuil = cuilNuevo;
            ListaProveedor.Add(nuevoProveedor);
            InstanciaPersistenciaDatos.GuardarArchivoProveedor(ListaProveedor);
            InstanciaPersistenciaDatos.GuardarArchivoProveedorEliminado(ListaProveedorEliminado);
        }


        //Baja Proveedor
        public void BajaProveedor(int idProveedor)
        {
            var proveedorEliminado = ListaProveedor.Find(x => idProveedor == x.idProveedor);
            ListaProveedorEliminado.Add(idProveedor);
            ListaProveedor.Remove(proveedorEliminado);
            InstanciaPersistenciaDatos.GuardarArchivoProveedor(ListaProveedor);
            InstanciaPersistenciaDatos.GuardarArchivoProveedorEliminado(ListaProveedorEliminado);
        }


        //Modificacion Proveedor 
        public void ModificarProveedor(int idProveedor, Persona personaNueva, long cuilNuevo)
        {
            var proveedorModificado = ListaProveedor.Find(x => idProveedor == x.idProveedor);
            proveedorModificado.idProveedor = idProveedor;
            proveedorModificado.nombre = personaNueva.nombre;
            proveedorModificado.apellido = personaNueva.apellido;
            proveedorModificado.direccion = personaNueva.direccion;
            proveedorModificado.telefono = personaNueva.telefono;
            proveedorModificado.cuil = cuilNuevo;
            var proveedorEliminado = ListaProveedor.Find(x => idProveedor == x.idProveedor);
            ListaProveedor.Remove(proveedorEliminado);
            ListaProveedor.Add(proveedorModificado);
            InstanciaPersistenciaDatos.GuardarArchivoProveedor(ListaProveedor);
        }


        //Validar Proveedor
        public List<Proveedor> ValidarProveedor()
        {
            ListaProveedor = InstanciaPersistenciaDatos.LeerArchivoProveedor();
            if (ListaProveedor == null)
            {
                List<Proveedor> nuevaListaProveedor = new List<Proveedor>();
                return nuevaListaProveedor;
            }
            return ListaProveedor;
        }


        //Validar Proveedor Eliminado
        public List<int> ValidarProveedorEliminado()
        {
            ListaProveedorEliminado = InstanciaPersistenciaDatos.LeerArchivoProveedorEliminado();
            if (ListaProveedorEliminado == null)
            {
                List<int> nuevaListaProveedorEliminado = new List<int>();
                return nuevaListaProveedorEliminado;
            }
            return ListaProveedorEliminado;
        }


        //Cuenta Cantidad de Proveedor
        public int ContarCantidadProveedor()
        {
            if (ListaProveedor == null)
            {
                return 0;
            }
            return ListaProveedor.Count;
        }


        //Buscar Proveedor Id
        public List<Proveedor> BuscarProveedorId(int idProveedor)
        {

            List<Proveedor> nuevaListaProveedor = new List<Proveedor>();
            if (ListaProveedor == null)
            {
                return nuevaListaProveedor;
            }
            else
            {
                var proveedorObtenido = ListaProveedor.Find(x => idProveedor == x.idProveedor);
                nuevaListaProveedor.Add(proveedorObtenido);
                nuevaListaProveedor.Sort(delegate (Proveedor x, Proveedor y)
                {
                    return x.idProveedor.CompareTo(y.idProveedor);
                });
                return nuevaListaProveedor;
            }
        }


        //Buscar Proveedor Por Nombre
        public List<Proveedor> BuscarProveedorNombre(string nombreProveedor)
        {
            ListaProveedor = ValidarProveedor();
            List<Proveedor> nuevaListaProveedor = new List<Proveedor>();
            foreach (var proveedor in ListaProveedor)
            {
                if (proveedor.nombre.ToString().ToLower().Contains(nombreProveedor.ToLower()))
                {
                    nuevaListaProveedor.Add(proveedor);
                }
            }
            nuevaListaProveedor.Sort(delegate (Proveedor x, Proveedor y)
            {
                return x.nombre.CompareTo(y.nombre);
            });
            return nuevaListaProveedor;
            
        }

        //Lista Proveedor por ID
        public List<Proveedor> ListaProveedores()
        {
            ListaProveedor = ValidarProveedor();
            if (ListaProveedor.Count < 2)
            {
                return ValidarProveedor();
            }
            ListaProveedor.Sort(delegate (Proveedor x, Proveedor y)
            {
                return x.idProveedor.CompareTo(y.idProveedor);
            });
            return ListaProveedor;
        }

        //Lista Proveedor por Nombre
        public List<Proveedor> ListaProveedoresPorNombre()
        {
            ListaProveedor = ValidarProveedor();
            if (ListaCliente.Count < 2)
            {
                return ValidarProveedor();
            }
            ListaProveedor.Sort(delegate (Proveedor x, Proveedor y)
            {
                return x.nombre.CompareTo(y.nombre);
            });
            return ListaProveedor;
        }

        //Alta Producto
        List<Producto> ListaProducto = new List<Producto>();
        List<int> ListaProductoEliminado = new List<int>();
        public void AltaProducto(string nombreNuevoProducto, string categoriaNuevoProducto, string descripcionNuevoProducto, int cantidadMinimaNuevoProducto, int cantidadActualNuevoProducto, long cuilProveedorNuevoProducto, int precioNuevoProducto)
        {
            Producto nuevoProducto = new Producto();
            if (ListaProductoEliminado.Count == 0)
            {if (ListaProducto == null)
                {
                    nuevoProducto.idProducto = 1;
                }
                int idnuevo = ListaProducto.Count;
                idnuevo ++;
                nuevoProducto.idProducto = idnuevo;

            }
            else
            {
                int idnuevo = ListaProductoEliminado.ElementAt(0);
                nuevoProducto.idProducto = idnuevo;
                ListaProductoEliminado.Remove(idnuevo);
            }
            var proveedorNuevoProducto = ListaProveedor.Find(x => cuilProveedorNuevoProducto == x.cuil);
            nuevoProducto.nombre = nombreNuevoProducto;
            nuevoProducto.categoria = categoriaNuevoProducto;
            nuevoProducto.descripcion = descripcionNuevoProducto;
            nuevoProducto.cantidadMinima = cantidadMinimaNuevoProducto;
            nuevoProducto.cantidadActual = cantidadActualNuevoProducto;
            nuevoProducto.precio = precioNuevoProducto;
            nuevoProducto.cuilProveedorProducto = proveedorNuevoProducto.cuil;
            nuevoProducto.nombreProveedorProducto = proveedorNuevoProducto.nombre;
            nuevoProducto.telefonoProveedorProducto = proveedorNuevoProducto.telefono;      
            ListaProducto.Add(nuevoProducto);
            InstanciaPersistenciaDatos.GuardarArchivoProducto(ListaProducto);
            InstanciaPersistenciaDatos.GuardarArchivoProductoEliminado(ListaProductoEliminado);
        }


        //Baja Producto
        public void BajaProducto(int idProducto)
        {
            var productoEliminado = ListaProducto.Find(x => idProducto == x.idProducto);
            ListaProductoEliminado.Add(idProducto);
            ListaProducto.Remove(productoEliminado);
            InstanciaPersistenciaDatos.GuardarArchivoProducto(ListaProducto);
            InstanciaPersistenciaDatos.GuardarArchivoProductoEliminado(ListaProductoEliminado);
        }


        //Modificacion Producto
        public void ModificarProducto(int idProducto, Producto productoNuevo)
        {
            var productoModificado = ListaProducto.Find(x => idProducto == x.idProducto);
            productoModificado.idProducto = idProducto;
            productoModificado.nombre = productoNuevo.nombre;
            productoModificado.precio = productoNuevo.precio;
            productoModificado.cantidadActual = productoNuevo.cantidadActual;
            productoModificado.cantidadMinima = productoNuevo.cantidadMinima;
            productoModificado.categoria = productoNuevo.categoria;
            productoModificado.descripcion = productoNuevo.descripcion;
            productoModificado.cuilProveedorProducto = productoNuevo.cuilProveedorProducto;
            var nuevoProveedor = ListaProveedor.Find(x => productoNuevo.cuilProveedorProducto == x.cuil);
            productoModificado.nombreProveedorProducto = nuevoProveedor.nombre;
            productoModificado.telefonoProveedorProducto = nuevoProveedor.telefono;
            var productoEliminado = ListaProducto.Find(x => idProducto == x.idProducto);
            ListaProducto.Remove(productoEliminado);
            ListaProducto.Add(productoModificado);
            InstanciaPersistenciaDatos.GuardarArchivoProducto(ListaProducto);
        }


        //Validar Producto
        public List<Producto> ValidarProducto()
        {
            ListaProducto = InstanciaPersistenciaDatos.LeerArchivoProducto();
            if (ListaProducto == null)
            {
                List<Producto> nuevaListaProducto = new List<Producto>();
                return nuevaListaProducto;
            }
            return ListaProducto;
        }


        //Validar Producto Eliminado
        public List<int> ValidarProductoEliminado()
        {
            ListaProductoEliminado = InstanciaPersistenciaDatos.LeerArchivoProductoEliminado();
            if (ListaProductoEliminado == null)
            {
                List<int> nuevaListaProductoEliminado = new List<int>();
                return nuevaListaProductoEliminado;
            }
            return ListaProductoEliminado;
        }


        //Cuenta Cantidad de Producto
        public int ContarCantidadProducto()
        {
            if (ListaProducto == null)
            {
                return 0;
            }
            return ListaProducto.Count;
        }



        //Buscar Producto Id
        public List<Producto> BuscarProductoId(int idProducto)
        {

            List<Producto> nuevaListaProducto = new List<Producto>();
            if (ListaProducto == null)
            {
                return nuevaListaProducto;
            }
            else
            {
                var productoObtenido = ListaProducto.Find(x => idProducto == x.idProducto);
                nuevaListaProducto.Add(productoObtenido);
                return nuevaListaProducto;
            }
        }


        //Buscar Producto Por Nombre
        public List<Producto> BuscarProductoNombre(string nombreProducto)
        {
            List<Producto> nuevaListaProducto = new List<Producto>();
            if (ListaProducto == null)
            {
                return nuevaListaProducto;
            }
            else
            {
                var productoObtenido = ListaProducto.Find(x => nombreProducto == x.nombre);
                return nuevaListaProducto;
            }
        }


        //Lista Producto
        public List<Producto> ListaProductos()
        {
            ListaProducto = ValidarProducto();
            if (ListaProducto.Count < 2)
            {
                return ValidarProducto();
            }
            ListaProducto.Sort(delegate (Producto x, Producto y)
            {
                return x.idProducto.CompareTo(y.idProducto);
            });
            return ListaProducto;
        }    
    }
}


