using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class VentasDetalle
    {
        [Key]
        public int VentaDetalleId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public double Itbis { get; set; }
        public double Importe { get; set; }


        public VentasDetalle(int ventaDetalleId, int ventaId, int productoId, int cantidad, double precio)
        {
            VentaDetalleId = ventaDetalleId;
            VentaId = ventaId;
            ProductoId = productoId;
            Cantidad = cantidad;
            Precio = precio;
        }

        public VentasDetalle()
        {
            VentaDetalleId = 0;
            VentaId = 0;
            ProductoId = 0;
            Cantidad = 0;
            Precio = 0;
            Itbis = 0;
            Importe = 0;
        }
    }
}
