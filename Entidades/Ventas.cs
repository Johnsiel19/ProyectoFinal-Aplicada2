using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public string Modo { get; set; }
        public double SubTotal { get; set; }
        public double Itbis { get; set; }
        public double Total { get; set; }
        public double Balance { get; set; }
        public DateTime Fecha { get; set; }

        public virtual List<VentasDetalle> Productos { get; set; }


        public Ventas()
        {
            VentaId = 0;
            ClienteId = 0;
            UsuarioId = 0;
            Modo = string.Empty;
            SubTotal = 0;
            Itbis = 0;
            Total = 0;
            Balance = 0;
            Fecha = DateTime.Now;
            Productos = new List<VentasDetalle>();

        }
    }
}
