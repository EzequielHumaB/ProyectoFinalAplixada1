using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using RecursosHumanosBLL;

namespace HorariosTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RepositorioBase<Horarios> repositorioBase = new RepositorioBase<Horarios>();
            Horarios horarios = new Horarios();
            horarios.EmpleadoId = 1;
            horarios.HorarioId = 1;
            horarios.HorarioEntrada = DateTime.Now;
            horarios.HorarioSalida = DateTime.Now;
            horarios.PrecioHorasExtras = 12;
            horarios.CantidadHorasExtras = 12;
            Assert.IsTrue(repositorioBase.Guardar(horarios));
        }

        [TestMethod]
        public void Buscar()
        {
            RepositorioBase<Horarios> repositorioBase = new RepositorioBase<Horarios>();
            Assert.IsNotNull(repositorioBase.Buscar(1));
        }

        [TestMethod]
        public void GetList()
        {
            RepositorioBase<Horarios> repositorioBase = new RepositorioBase<Horarios>();
            Assert.IsNotNull(repositorioBase.GetList(p=>true));
        }

        [TestMethod]
        public void Modificar()
        {
            RepositorioBase<Horarios> repositorioBase = new RepositorioBase<Horarios>();
            Horarios horarios = new Horarios();
            horarios.EmpleadoId = 1;
            horarios.HorarioId = 1;
            horarios.HorarioEntrada = DateTime.Now;
            horarios.HorarioSalida = DateTime.Now;
            horarios.PrecioHorasExtras = 12;
            horarios.CantidadHorasExtras = 122;
            Assert.IsTrue(repositorioBase.Guardar(horarios));
        }

        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Horarios> repositorioBase = new RepositorioBase<Horarios>();
            Assert.IsTrue(repositorioBase.Eliminar(1));
        }

    }
}
