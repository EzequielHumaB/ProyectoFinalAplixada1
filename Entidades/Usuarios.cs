using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entidades
{
   public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public string NivelUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ClaveUsuario { get; set; }
 
        public Usuarios()
        {
            UsuarioId = 0;
            Usuario = string.Empty;
            NivelUsuario = string.Empty;
            FechaCreacion = DateTime.Now;;
            ClaveUsuario = string.Empty;
        }
        
     
    }
}
