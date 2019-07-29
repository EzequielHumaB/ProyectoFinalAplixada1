using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entidades
{
    public class Horarios
    {
        [Key]
        [Browsable(false)]
        public int HorarioId { get; set; }
        public DateTime HorarioEntrada { get; set; }

        public DateTime HorarioSalida { get; set; }

        public int EmpleadoId {get;set;}
        public int CantidadHorasExtras { get; set; }
        public decimal PrecioHorasExtras { get; set; }

        

        public Horarios()
        {
            HorarioId = 0;
            HorarioEntrada = DateTime.Now;
            EmpleadoId = 0;
            CantidadHorasExtras = 0;
            PrecioHorasExtras = 0;
            HorarioSalida = DateTime.Now;
        }
        public Horarios(int IdHorario, DateTime FechasHorario, DateTime SalidaHorario,int IdEmpleado, int HorasExtresCantidad, int HorasExtrasPrecio)
        {
            HorarioId = IdHorario;
            HorarioEntrada = FechasHorario;
            HorarioSalida = SalidaHorario;
            EmpleadoId = IdEmpleado;
            CantidadHorasExtras = HorasExtresCantidad;
            PrecioHorasExtras = HorasExtrasPrecio;
        }

        public Horarios(DateTime fechaHorario,DateTime SalidaHorario, int HorasExtrasCantidad, decimal HorasExtrasPrecio)
        {
            HorarioEntrada = fechaHorario;
            HorarioSalida = SalidaHorario;
            CantidadHorasExtras = HorasExtrasCantidad;
            PrecioHorasExtras = HorasExtrasPrecio;
        }
    }
}
