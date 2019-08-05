using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entidades
{
    public class Contratos
    {
        [Key]
        [Browsable(false)]
        public int ContratoId { get; set; }
        public string DescripcionContrato { get; set; }
        public string Seguro { get; set; }
        public decimal Salario { get; set; }
        [Browsable(false)]
        public int EmpleadoId { get; set; }

        public DateTime FechaCreacion { get; set; }
       
        public virtual List<Horarios> Horarios { get; set; }

        public Contratos()
        {
            ContratoId = 0;
            DescripcionContrato = string.Empty;
            Seguro = string.Empty;
            Salario = 0;
            EmpleadoId = 0;
            FechaCreacion = DateTime.Now;
            Horarios = new List<Horarios>();
        }
    }
    
}
