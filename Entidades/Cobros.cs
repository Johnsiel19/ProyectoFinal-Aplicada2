using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Cobros
    {
        [Key]
        public int CobroId { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public int VentaId { get; set; }
        public decimal MontoPagado { get; set; }
        public DateTime Fecha { get; set; }
        public string Observacion { get; set; }

        public Cobros()
        {
            CobroId = 0;
            ClienteId = 0;
            UsuarioId = 0;
            VentaId = 0;
            MontoPagado = 0;
            Fecha = DateTime.Now;
            Observacion = string.Empty;
        }
    }
}
