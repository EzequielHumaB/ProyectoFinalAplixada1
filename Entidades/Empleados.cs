using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entidades
{
  public class Empleados
    {
        [Key]
        [Browsable(false)]
        public int EmpleadoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Nacionalidad { get; set; }
        public String EstadoCivil { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaIngreso { get; set; }


        public Empleados()
        {
            EmpleadoId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Cedula = string.Empty;
            FechaNacimiento = DateTime.Now;
            Nacionalidad = string.Empty;
            EstadoCivil = string.Empty;
            Salario = 0;
            FechaIngreso = DateTime.Now;
        }

    }
}
