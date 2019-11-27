using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VentaBLL
    {



        public static bool Guardar(Ventas venta)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                RepositorioBase<Productos> prod = new RepositorioBase<Productos>();
                RepositorioBase<Clientes> client = new RepositorioBase<Clientes>();



                if (db.Ventas.Add(venta) != null)
                {

                    foreach (var item in venta.Detalle)
                    {
                        var producto = prod.Buscar(item.ProductoId);
                        producto.Existencia = producto.Existencia - item.Cantidad;
                        prod.Modificar(producto);

                    }

                    var cliente = client.Buscar(venta.ClienteId);
                    cliente.Balance = cliente.Balance + venta.Balance;
                    client.Modificar(cliente);

                    paso = db.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Ventas> vent = new RepositorioBase<Ventas>();
            RepositorioBase<Productos> prod = new RepositorioBase<Productos>();
            RepositorioBase<Clientes> client = new RepositorioBase<Clientes>();


            try
            {
                Ventas venta = db.Ventas.Find(id);
                var cliente = client.Buscar(venta.ClienteId);
                cliente.Balance = cliente.Balance - venta.Total;
                client.Modificar(cliente);

                foreach (var item in venta.Detalle)
                {
                    var producto = prod.Buscar(item.ProductoId);
                    producto.Existencia = producto.Existencia + item.Cantidad;
                    prod.Modificar(producto);

                }


                db.Ventas.Remove(venta);
                if (db.SaveChanges() > 0)
                {
                    paso = true;

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static void ModificarBien(Ventas ventas, Ventas VentasAnteriores)
        {
            Contexto contexto = new Contexto();

            RepositorioBase<Clientes> client = new RepositorioBase<Clientes>();
            RepositorioBase<Ventas> vent = new RepositorioBase<Ventas>();





            var Cliente = client.Buscar(ventas.ClienteId);
            var ClientesAnteriores = client.Buscar(VentasAnteriores.ClienteId);

            Cliente.Balance += ventas.Total;
            ClientesAnteriores.Balance -= VentasAnteriores.Total;
            client.Modificar(Cliente);
            client.Modificar(ClientesAnteriores);






        }

        public static bool Modificar(Ventas ventas)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Clientes> client = new RepositorioBase<Clientes>();
            RepositorioBase<Ventas> vent = new RepositorioBase<Ventas>();
            RepositorioBase<Productos> prod = new RepositorioBase<Productos>();
            try
            {
                var venta = vent.Buscar(ventas.VentaId);

                if (ventas.ClienteId != venta.ClienteId)
                {
                    ModificarBien(ventas, venta);
                }

                if (ventas != null)
                {
                    foreach (var item in venta.Detalle)
                    {
                        db.Productos.Find(item.ProductoId).Existencia += item.Cantidad;

                        if (!ventas.Detalle.ToList().Exists(v => v.VentaDetalleId == item.VentaDetalleId))
                        {

                            db.Entry(item).State = EntityState.Deleted;
                        }
                    }

                    foreach (var item in ventas.Detalle)
                    {
                        db.Productos.Find(item.ProductoId).Existencia -= item.Cantidad;
                        var estado = item.VentaDetalleId > 0 ? EntityState.Modified : EntityState.Added;
                        db.Entry(item).State = estado;
                    }

                    db.Entry(ventas).State = EntityState.Modified;
                }

                Modifica(ventas, venta, db);

                db.SaveChanges();
               
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static void Modifica(Ventas factura, Ventas FactAnt, Contexto contexto)
        {
            RepositorioBase<Clientes> client = new RepositorioBase<Clientes>();
            RepositorioBase<Ventas> venta = new RepositorioBase<Ventas>();



            decimal modificado = factura.Total - FactAnt.Total;

            var Cliente = client.Buscar(factura.ClienteId);
            Cliente.Balance += modificado;
            client.Modificar(Cliente);




            decimal balance = factura.Total - FactAnt.Total;
            FactAnt.Balance += balance;
            factura.Balance = FactAnt.Balance;
            venta.Modificar(factura);

        }


    }
}
