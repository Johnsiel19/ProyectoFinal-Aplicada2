using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BLL.Tests
{
    [TestClass()]
    public class VentaBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();


            Ventas ve = new Ventas()
            {
                VentaId = 1,
                ClienteId = 1,
                UsuarioId = 3,
                Total = 9,
                Fecha = DateTime.Now
            };
            Assert.IsTrue(db.Guardar(ve));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();

            Ventas ve = new Ventas()
            {
                VentaId = 2,
                ClienteId = 0,
                UsuarioId = 0,
                Total = 0,
                Fecha = DateTime.Now
            };

            Assert.IsTrue(db.Modificar(ve));
        }


        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();

            Assert.IsTrue(db.Eliminar(1));
        }
    }
}