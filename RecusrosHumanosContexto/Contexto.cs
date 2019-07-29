using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entidades;

namespace RecusrosHumanosContexto
{
    public class Contexto : DbContext
    {
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Contratos> contratos { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }

        public DbSet<TipoVacante> tipoVacantes { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public Contexto() : base("ConStr")
        {
            Database.SetInitializer<Contexto>(new DropCreateDatabaseIfModelChanges<Contexto>());
        }
    }
}
