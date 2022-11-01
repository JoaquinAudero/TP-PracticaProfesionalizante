using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Logica
{
    public class PersistenciaDatos
    {
        //Ruta De Archivos
        readonly string RutaListaCliente = @"C:\Repo\Kiosco Practica Profesionalizante\Kiosco\ArchivosTxt\ListaCliente.txt";
        readonly string RutaListaClienteEliminado = @"C:\Repo\Kiosco Practica Profesionalizante\Kiosco\ArchivosTxt\ListaClienteEliminado.txt";
        readonly string RutaListaDelivery = @"C:\Repo\Kiosco Practica Profesionalizante\Kiosco\ArchivosTxt\ListaDelivery.txt";
        readonly string RutaListaDeliveryEliminado = @"C:\Repo\Kiosco Practica Profesionalizante\Kiosco\ArchivosTxt\ListaDeliveryEliminado.txt";
        readonly string RutaListaProveedor = @"C:\Repo\Kiosco Practica Profesionalizante\Kiosco\ArchivosTxt\ListaProveedor.txt";
        readonly string RutaListaProveedorEliminado = @"C:\Repo\Kiosco Practica Profesionalizante\Kiosco\ArchivosTxt\ListaProveedorEliminado.txt";
        readonly string RutaListaProducto = @"C:\Repo\Kiosco Practica Profesionalizante\Kiosco\ArchivosTxt\ListaProducto.txt";
        readonly string RutaListaProductoEliminado = @"C:\Repo\Kiosco Practica Profesionalizante\Kiosco\ArchivosTxt\ListaProductoEliminado.txt";


        //Creación De Archivos
        public void InicializarArchivos()
        {
            if (!File.Exists(RutaListaCliente))
            {
                File.Create(RutaListaCliente).Close();
            }
            if (!File.Exists(RutaListaClienteEliminado))
            {
                File.Create(RutaListaClienteEliminado).Close();
            }
            if (!File.Exists(RutaListaDelivery))
            {
                File.Create(RutaListaDelivery).Close();
            }
            if (!File.Exists(RutaListaDeliveryEliminado))
            {
                File.Create(RutaListaDeliveryEliminado).Close();
            }
            if (!File.Exists(RutaListaProducto))
            {
                File.Create(RutaListaProducto).Close();
            }
            if (!File.Exists(RutaListaProductoEliminado))
            {
                File.Create(RutaListaProductoEliminado).Close();
            }
            if (!File.Exists(RutaListaProveedor))
            {
                File.Create(RutaListaProveedor).Close();
            }
            if (!File.Exists(RutaListaProveedorEliminado))
            {
                File.Create(RutaListaProveedorEliminado).Close();
            }
        }


        //Lectura de Archivos
        public List<Cliente> LeerArchivoCliente()
        {
            string locationFile = RutaListaCliente;
            using (StreamReader reder = new StreamReader(locationFile))
            {
                string content = reder.ReadToEnd();
                List<Cliente> listaCliente = JsonConvert.DeserializeObject<List<Cliente>>(content);
                return listaCliente;
            }
        }



        public List<int> LeerArchivoClienteEliminado()
        {
            string locationFile = RutaListaClienteEliminado;
            using (StreamReader reder = new StreamReader(locationFile))
            {
                string content = reder.ReadToEnd();
                List<int> listaClienteEliminado = JsonConvert.DeserializeObject<List<int>>(content);
                return listaClienteEliminado;
            }
        }


        public List<Delivery> LeerArchivoDelivery()
        {
            string locationFile = RutaListaDelivery;
            using (StreamReader reder = new StreamReader(locationFile))
            {
                string content = reder.ReadToEnd();
                List<Delivery> listaDelivery = JsonConvert.DeserializeObject<List<Delivery>>(content);
                return listaDelivery;
            }
        }


        public List<int> LeerArchivoDeliveryEliminado()
        {
            string locationFile = RutaListaDeliveryEliminado;
            using (StreamReader reder = new StreamReader(locationFile))
            {
                string content = reder.ReadToEnd();
                List<int> listaDeliveryEliminado = JsonConvert.DeserializeObject<List<int>>(content);
                return listaDeliveryEliminado;
            }
        }


        public List<Producto> LeerArchivoProducto()
        {
            string locationFile = RutaListaProducto;
            using (StreamReader reder = new StreamReader(locationFile))
            {
                string content = reder.ReadToEnd();
                List<Producto> listaProducto = JsonConvert.DeserializeObject<List<Producto>>(content);
                return listaProducto;
            }
        }


        public List<int> LeerArchivoProductoEliminado()
        {
            string locationFile = RutaListaProductoEliminado;
            using (StreamReader reder = new StreamReader(locationFile))
            {
                string content = reder.ReadToEnd();
                List<int> listaProductoEliminado = JsonConvert.DeserializeObject<List<int>>(content);
                return listaProductoEliminado;
            }
        }


        public List<Proveedor> LeerArchivoProveedor()
        {
            string locationFile = RutaListaProveedor;
            using (StreamReader reder = new StreamReader(locationFile))
            {
                string content = reder.ReadToEnd();
                List<Proveedor> listaProveedor = JsonConvert.DeserializeObject<List<Proveedor>>(content);
                return listaProveedor;
            }
        }


        public List<int> LeerArchivoProveedorEliminado()
        {
            string locationFile = RutaListaProveedorEliminado;
            using (StreamReader reder = new StreamReader(locationFile))
            {
                string content = reder.ReadToEnd();
                List<int> listaProveedorEliminado = JsonConvert.DeserializeObject<List<int>>(content);
                return listaProveedorEliminado;
            }
        }


        //Guardar Archivos
        public void GuardarArchivoCliente(List<Cliente> ListaCliente)
        {
            string locationFile = RutaListaCliente;
            using (StreamWriter writer = new StreamWriter(locationFile, false))
            {
                string jsonContent = JsonConvert.SerializeObject(ListaCliente);
                writer.Write(jsonContent);
            }
        }


        public void GuardarArchivoClienteEliminado(List<int> ListaClienteEliminado)
        {
            string locationFile = RutaListaClienteEliminado;
            using (StreamWriter writer = new StreamWriter(locationFile, false))
            {
                string jsonContent = JsonConvert.SerializeObject(ListaClienteEliminado);
                writer.Write(jsonContent);
            }
        }


        public void GuardarArchivoDelivery(List<Delivery> ListaDelivery)
        {
            string locationFile = RutaListaDelivery;
            using (StreamWriter writer = new StreamWriter(locationFile, false))
            {
                string jsonContent = JsonConvert.SerializeObject(ListaDelivery);
                writer.Write(jsonContent);
            }
        }


        public void GuardarArchivoDeliveryEliminado(List<int> ListaDeliveryEliminado)
        {
            string locationFile = RutaListaDeliveryEliminado;
            using (StreamWriter writer = new StreamWriter(locationFile, false))
            {
                string jsonContent = JsonConvert.SerializeObject(ListaDeliveryEliminado);
                writer.Write(jsonContent);
            }
        }


        public void GuardarArchivoProducto(List<Producto> ListaProducto)
        {
            string locationFile = RutaListaProducto;
            using (StreamWriter writer = new StreamWriter(locationFile, false))
            {
                string jsonContent = JsonConvert.SerializeObject(ListaProducto);
                writer.Write(jsonContent);
            }
        }


        public void GuardarArchivoProductoEliminado(List<int> ListaProductoEliminado)
        {
            string locationFile = RutaListaProductoEliminado;
            using (StreamWriter writer = new StreamWriter(locationFile, false))
            {
                string jsonContent = JsonConvert.SerializeObject(ListaProductoEliminado);
                writer.Write(jsonContent);
            }
        }


        public void GuardarArchivoProveedor(List<Proveedor> ListaProveedor)
        {
            string locationFile = RutaListaProveedor;
            using (StreamWriter writer = new StreamWriter(locationFile, false))
            {
                string jsonContent = JsonConvert.SerializeObject(ListaProveedor);
                writer.Write(jsonContent);
            }
        }



        public void GuardarArchivoProveedorEliminado(List<int> ListaProveedorEliminado)
        {
            string locationFile = RutaListaProveedorEliminado;
            using (StreamWriter writer = new StreamWriter(locationFile, false))
            {
                string jsonContent = JsonConvert.SerializeObject(ListaProveedorEliminado);
                writer.Write(jsonContent);
            }
        }
    }
}
