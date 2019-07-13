using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
  public class Empleados
    {
        [Key]
        public int EmpleadoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string EstadoCivil { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int DepartamentoId { get; set; }
        public int ContratoId { get; set; }
        public virtual List<Horarios> Horarios { get; set; }

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
            DepartamentoId = 0;
            ContratoId = 0;
            Horarios = new List<Horarios>();
        }

    }
}
