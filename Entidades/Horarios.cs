using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Horarios
    {
        public int HorarioId { get; set; }
        public DateTime HorarioFechas { get; set; }
        public int EmpleadoId {get;set;}

        public Horarios()
        {
            HorarioId = 0;
            HorarioFechas = DateTime.Now;
            EmpleadoId = 0;
        }
        public Horarios(int IdHorario, DateTime FechasHorario, int IdEmpleado)
        {
            HorarioId = IdHorario;
            HorarioFechas = FechasHorario;
            EmpleadoId = IdEmpleado;
        }
    }
}
