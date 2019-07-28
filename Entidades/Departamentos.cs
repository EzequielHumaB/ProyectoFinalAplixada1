using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
   public class Departamentos
    {
        [Key]
        public  int DepartamentoId { get; set; }
        public string NombreDepartamento { get; set; }

        public DateTime FechaCreacion { get; set; }

        public Departamentos()
        {
            DepartamentoId = 0;
            NombreDepartamento = string.Empty;
            FechaCreacion = DateTime.Now;
        }
    }

}
