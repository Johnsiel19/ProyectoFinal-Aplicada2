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
    public class CobrosBLL
    {
        public static bool Guardar(Cobros cobro)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                RepositorioBase<Ventas> vent = new RepositorioBase<Ventas>();
                RepositorioBase<Clientes> client = new RepositorioBase<Clientes>();


                if (db.Cobros.Add(cobro) != null)
                {
                    var cliente = client.Buscar(cobro.ClienteId);
                    cliente.Balance = cliente.Balance - cobro.MontoPagado;
                    client.Modificar(cliente);


                    var Venta = vent.Buscar(cobro.VentaId);
                    Venta.Balance = Venta.Balance - cobro.MontoPagado;
                    vent.Modificar(Venta);

                    paso = db.SaveChanges() > 0;

                }

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Modificar(Cobros cobro)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Ventas> vent = new RepositorioBase<Ventas>();
            RepositorioBase<Clientes> client = new RepositorioBase<Clientes>();
            RepositorioBase<Cobros> cobr = new RepositorioBase<Cobros>();

            try
            {


                var anterior = cobr.Buscar(cobro.ClienteId);
                var cliente = client.Buscar(cobro.ClienteId);

                cliente.Balance = cliente.Balance + (cobro.MontoPagado - anterior.MontoPagado);
                client.Modificar(cliente);

                var Venta = vent.Buscar(cobro.VentaId);
                Venta.Balance = Venta.Balance + (cobro.MontoPagado - anterior.MontoPagado);
                vent.Modificar(Venta);


                db.Entry(cobro).State = EntityState.Modified;

                paso = db.SaveChanges() > 0;


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
            RepositorioBase<Cobros> cobr = new RepositorioBase<Cobros>();
            RepositorioBase<Clientes> client = new RepositorioBase<Clientes>();

            try
            {

                var cobro = cobr.Buscar(id);
                var ventas = vent.Buscar(cobro.VentaId);
                var cliente = client.Buscar(cobro.ClienteId);


                ventas.Balance = ventas.Balance + cobro.MontoPagado;
                cliente.Balance = cliente.Balance + cobro.MontoPagado;
                client.Modificar(cliente);
                vent.Modificar(ventas);
                db.Entry(cobro).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
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

    }
}
