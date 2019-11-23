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
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Itbis { get; set; }
        public decimal Importe { get; set; }

        public VentasDetalle(int ventaDetalleId, int ventaId, int productoId, string descripcion, decimal cantidad, decimal precio, decimal itbis, decimal importe)
        {
            VentaDetalleId = ventaDetalleId;
            VentaId = ventaId;
            ProductoId = productoId;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Precio = precio;
            Itbis = itbis;
            Importe = importe;
        }

        public VentasDetalle()
        {
            VentaDetalleId = 0;
            VentaId = 0;
            Descripcion = string.Empty;
            ProductoId = 0;
            Cantidad = 0;
            Precio = 0;
            Itbis = 0;
            Importe = 0;
        }
    }
}
