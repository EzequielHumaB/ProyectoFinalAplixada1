using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using RecursosHumanosBLL;

namespace TipoVacantesTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RepositorioBase<TipoVacante> repositorioBase = new RepositorioBase<TipoVacante>();
            TipoVacante tipoVacante = new TipoVacante();
            tipoVacante.TipoVacanteId = 1;
            tipoVacante.NombreTipoVacante = "Vacante";
            tipoVacante.FechaCreacion = DateTime.Now;
            Assert.IsTrue(repositorioBase.Guardar(tipoVacante));
        }

        [TestMethod]
        public void Buscar()
        {
            RepositorioBase<TipoVacante> repositorioBase = new RepositorioBase<TipoVacante>();
            Assert.IsNotNull(repositorioBase.Buscar(1));
        }

        [TestMethod]
        public void GetList()
        {
            RepositorioBase<TipoVacante> repositorioBase = new RepositorioBase<TipoVacante>();
            Assert.IsNotNull(repositorioBase.GetList(p => true));
        }

        [TestMethod]
        public void Modificar1()
        {
            RepositorioBase<TipoVacante> repositorioBase = new RepositorioBase<TipoVacante>();
            TipoVacante tipoVacante = new TipoVacante();
            tipoVacante.TipoVacanteId = 1;
            tipoVacante.NombreTipoVacante = "Vacantes";
            tipoVacante.FechaCreacion = DateTime.Now;
            Assert.IsTrue(repositorioBase.Modificar(tipoVacante));
        }

        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<TipoVacante> repositorioBase = new RepositorioBase<TipoVacante>();
            Assert.IsTrue(repositorioBase.Eliminar(1));
        }


    }
}
