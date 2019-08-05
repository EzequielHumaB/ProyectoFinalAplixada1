using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using RecursosHumanosBLL;

namespace EmpleadoTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RepositorioBase<Empleados> repositorioBase = new RepositorioBase<Empleados>();
            Empleados empleados = new Empleados();
            empleados.EmpleadoId = 1;
            empleados.Cedula = "40214436707";
            empleados.Nombres = "Maria";
            empleados.Apellidos = "Hernandez";
            empleados.Celular = "8494321234";
            empleados.Telefono = "8095882985";
            empleados.Nacionalidad = "Nacionalidad";
            empleados.FechaNacimiento = new DateTime(2001,12,12);
            empleados.FechaIngreso = DateTime.Now;
            empleados.Salario = 10000000;
            empleados.EstadoCivil = "Soltero";
            Assert.IsTrue(repositorioBase.Guardar(empleados));
        }

        [TestMethod()]
        public void Buscar()
        {
            RepositorioBase<Empleados> repositorioBase = new RepositorioBase<Empleados>();
            Assert.IsNotNull(repositorioBase.Buscar(1));
        }

        [TestMethod()]
        public void GetList()
        {
            RepositorioBase<Empleados> repositorioBase = new RepositorioBase<Empleados>();
            Assert.IsNotNull(repositorioBase.GetList(p => true));
        }

        [TestMethod()]
        public void Modificar()
        {
            RepositorioBase<Empleados> repositorioBase = new RepositorioBase<Empleados>();
            Empleados empleados = new Empleados();
            empleados.EmpleadoId = 1;
            empleados.Cedula = "4021443670";
            empleados.Nombres = "Maria";
            empleados.Apellidos = "Hernandez Salazar";
            empleados.Celular = "8494321234";
            empleados.Telefono = "8095882985";
            empleados.Nacionalidad = "Nacionalidad";
            empleados.FechaNacimiento = new DateTime(2001, 12, 12);
            empleados.FechaIngreso = DateTime.Now;
            empleados.Salario = 10000000;
            Assert.IsTrue(repositorioBase.Modificar(empleados));
        }

        [TestMethod()]
        public void Eliminar()
        {
            RepositorioBase<Empleados> repositorioBase = new RepositorioBase<Empleados>();
            Assert.IsTrue(repositorioBase.Eliminar(1));
        }
    }
}
