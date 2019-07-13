using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entidades;

namespace TrabajoFinalRecursosHumanos
{
   public class RecursosHumanosContexto : DbContext
    {
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Contratos> contratos { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }

        public RecursosHumanosContexto() : base("ConStr")
        { }
    }
}
