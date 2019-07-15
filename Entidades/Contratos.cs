using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
   public class Contratos
    {
        [Key]
        public int ContratoId { get; set; }
        public string DescripcionContrato { get; set; }
        public string Seguro { get; set; }
        public decimal Sueldo { get; set; }

        public Contratos()
        {
            ContratoId = 0;
            DescripcionContrato = string.Empty;
            Seguro = string.Empty;
            Sueldo = 0;
        }
    }
    
}
