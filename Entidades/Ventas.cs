using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public string Modo { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Itbis { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public DateTime Fecha { get; set; }

        public virtual List<VentasDetalle> Detalle { get; set; }


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
            Detalle = new List<VentasDetalle>();

        }
    }
}
