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

    public class EntradaBLL
    {

        public static bool Guardar(Entradas entrada)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {

                RepositorioBase<Productos> prod = new RepositorioBase<Productos>();


                if (db.Entradas.Add(entrada) != null)
                {
                    var producto = prod.Buscar(entrada.ProductoId);
                    producto.Existencia = producto.Existencia + entrada.Entrada;
                    prod.Modificar(producto);

                    paso = db.SaveChanges() > 0;

                }

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Modificar(Entradas entrada)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Productos> prod = new RepositorioBase<Productos>();
            RepositorioBase<Entradas> entr = new RepositorioBase<Entradas>();

            try
            {

                var anterior = entr.Buscar(entrada.EntradaId);
                var producto = prod.Buscar(entrada.ProductoId);

                producto.Existencia = producto.Existencia + (entrada.Entrada - anterior.Entrada);
                prod.Modificar(producto);


                db.Entry(entrada).State = EntityState.Modified;

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
            RepositorioBase<Productos> prod = new RepositorioBase<Productos>();
            RepositorioBase<Entradas> entr = new RepositorioBase<Entradas>();



            try
            {

                var entrada = entr.Buscar(id);
                var producto = prod.Buscar(entrada.ProductoId);

                producto.Existencia = producto.Existencia - entrada.Entrada;
                prod.Modificar(producto);

                db.Entry(entrada).State = EntityState.Deleted;
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
