using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Cobros> Cobros { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Entradas> Entradas { get; set; }

        public Contexto() : base("ConStr")
        { }
    }
}
