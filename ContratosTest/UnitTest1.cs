using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using RecursosHumanosBLL;

namespace ContratosTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RepositorioBase<Contratos> repositorioBase = new RepositorioBase<Contratos>();
            Contratos contratos = new Contratos();
            contratos.ContratoId = 1;
            contratos.DescripcionContrato = "descripcion";
            contratos.EmpleadoId = 1;
            contratos.FechaCreacion = DateTime.Now;
            contratos.Salario = 19999;
            contratos.Seguro = "Seguro";
            Assert.IsTrue(repositorioBase.Guardar(contratos));
        }

   

        [TestMethod]
        public void Buscar()
        {
            RepositorioBase<Contratos> repositorioBase = new RepositorioBase<Contratos>();
            Assert.IsNotNull(repositorioBase.Buscar(1));
        }

        [TestMethod]
        public void GetList()
        {
            RepositorioBase<Contratos> repositorioBase = new RepositorioBase<Contratos>();
            Assert.IsNotNull(repositorioBase.GetList(p=>true));
        }
        [TestMethod]
        public void Modificar()
        {
            RepositorioBase<Contratos> repositorioBase = new RepositorioBase<Contratos>();
            Contratos contratos = new Contratos();
            contratos.ContratoId = 1;
            contratos.DescripcionContrato = "descripcion";
            contratos.EmpleadoId = 1;
            contratos.FechaCreacion = DateTime.Now;
            contratos.Salario = 19999;
            contratos.Seguro = "Seguros";
            Assert.IsTrue(repositorioBase.Guardar(contratos));
        }
        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Contratos> repositorioBase = new RepositorioBase<Contratos>();
            Assert.IsTrue(repositorioBase.Eliminar(1));
        }
    }
}
