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
    public class EntradaBLLTests
    {
            [TestMethod()]
            public void GuardarTest()
            {



                Entradas ve = new Entradas()
                {

                    ProductoId = 1,
                    UsuarioId = 3,
                    Entrada = 9,
                    Fecha = DateTime.Now
                };
                Assert.IsTrue(EntradaBLL.Guardar(ve));
            }

            [TestMethod()]
            public void ModificarTest()
            {


                Entradas ve = new Entradas()
                {
                    EntradaId = 2,
                    ProductoId = 1,
                    UsuarioId = 3,
                    Entrada = 9,
                    Fecha = DateTime.Now
                };

                Assert.IsTrue(EntradaBLL.Modificar(ve));
            }


            [TestMethod()]
            public void EliminarTest()
            {


                Assert.IsTrue(EntradaBLL.Eliminar(1));
            }
        }
    }    