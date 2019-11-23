using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Entradas
    {
        [Key]
        public int EntradaId { get; set; }
        public int ProductoId { get; set; }
        public decimal Entrada { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }

        public Entradas()
        {
            EntradaId = 0;
            ProductoId = 0;
            Entrada = 0;
            UsuarioId = 0;
            Fecha = DateTime.Now;
        }
    }
}
