using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using RecursosHumanosBLL;

namespace DepartamentoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RepositorioBase<Departamentos> repositorioBase = new RepositorioBase<Departamentos>();
            Departamentos departamentos = new Departamentos();
            departamentos.DepartamentoId = 1;
            departamentos.NombreDepartamento = "Deparpamento";
            departamentos.FechaCreacion = DateTime.Now;
            Assert.IsTrue(repositorioBase.Guardar(departamentos));
        }

        [TestMethod]
        public void Buscar()
        {
            RepositorioBase<Departamentos> repositorioBase = new RepositorioBase<Departamentos>();
            Assert.IsNotNull(repositorioBase.Buscar(1));
        }

        [TestMethod]
        public void Modificar()
        {
            RepositorioBase<Departamentos> repositorioBase = new RepositorioBase<Departamentos>();
            Departamentos departamentos = new Departamentos();
            departamentos.DepartamentoId = 1;
            departamentos.NombreDepartamento = "Deparpamentosss";
            departamentos.FechaCreacion = DateTime.Now;
            Assert.IsTrue(repositorioBase.Modificar(departamentos));
        }

        [TestMethod]
        public void GetList()
        {
            RepositorioBase<Departamentos> repositorioBase = new RepositorioBase<Departamentos>();
            Assert.IsNotNull(repositorioBase.GetList(p => true));
        }

        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Departamentos> repositorioBase = new RepositorioBase<Departamentos>();
            Assert.IsTrue(repositorioBase.Eliminar(1));

        }
    }
}
