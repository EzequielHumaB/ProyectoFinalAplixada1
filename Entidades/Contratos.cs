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
        public decimal Salario { get; set; }
        public string Puesto { get; set; }
        public int EmpleadoId { get; set; }
        public virtual List<Horarios> Horarios { get; set; }

        public Contratos()
        {
            ContratoId = 0;
            DescripcionContrato = string.Empty;
            Seguro = string.Empty;
            Salario = 0;
            Puesto = string.Empty;
            EmpleadoId = 0;
            Horarios = new List<Horarios>();
        }
    }
    
}
