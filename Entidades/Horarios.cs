using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Horarios
    {
        [Key]
        public int HorarioId { get; set; }
        public DateTime HorarioFechas { get; set; }
        public int EmpleadoId {get;set;}
        public int CantidadHorasExtras { get; set; }
        public decimal PrecioHorasExtras { get; set; }

        public Horarios()
        {
            HorarioId = 0;
            HorarioFechas = DateTime.Now;
            EmpleadoId = 0;
            CantidadHorasExtras = 0;
            PrecioHorasExtras = 0;
        }
        public Horarios(int IdHorario, DateTime FechasHorario, int IdEmpleado, int HorasExtresCantidad, int HorasExtrasPrecio)
        {
            HorarioId = IdHorario;
            HorarioFechas = FechasHorario;
            EmpleadoId = IdEmpleado;
            CantidadHorasExtras = HorasExtresCantidad;
            PrecioHorasExtras = HorasExtrasPrecio;
        }

        public Horarios(DateTime fechaHorario, int HorasExtrasCantidad, decimal HorasExtrasPrecio)
        {
            HorarioFechas = fechaHorario;
            CantidadHorasExtras = HorasExtrasCantidad;
            PrecioHorasExtras = HorasExtrasPrecio;
        }
    }
}
