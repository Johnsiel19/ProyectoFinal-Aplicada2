using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public int UsuarioId { get; set; }
        public double Balance { get; set; }
        public DateTime Fecha { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            Nombre = string.Empty;
            Cedula = string.Empty;
            Email = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Direccion = string.Empty;
            UsuarioId = 0;
            Balance = 0.00;
            Fecha = DateTime.Now;
        }
    }
}
