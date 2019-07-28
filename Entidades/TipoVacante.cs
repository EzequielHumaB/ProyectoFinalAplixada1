using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
   public class TipoVacante
    {
        [Key]
        public int TipoVacanteId { get; set; }
        public string NombreTipoVacante { get; set; }
        public DateTime FechaCreacion { get; set; }
        
        public TipoVacante()
        {
            TipoVacanteId = 0;
            NombreTipoVacante = string.Empty;
            FechaCreacion = DateTime.Now;
        }
    

    }
}
