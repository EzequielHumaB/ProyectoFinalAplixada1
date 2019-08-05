using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecursosHumanosBLL;
using Entidades;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


namespace UsuarioTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();
            usuarios.Usuario = "Usuario";
            usuarios.ClaveUsuario = "9876543232";
            usuarios.FechaCreacion = DateTime.Now;
            usuarios.NivelUsuario = "Administrador";
            usuarios.UsuarioId = 2;
            Assert.IsTrue(repositorioBase.Guardar(usuarios));
       }

        [TestMethod()]
        public void Buscar()
        {
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            Assert.IsNotNull(repositorioBase.Buscar(2));
        }

        [TestMethod]
        public void GetList()
        {
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            List<Usuarios> usuarios = new List<Usuarios>();
            Assert.IsNotNull(repositorioBase.GetList(p => true));
        }

        [TestMethod]
        public void Modificar()
        {
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();
            usuarios.Usuario = "Usuariosss";
            usuarios.ClaveUsuario = "9876543232";
            usuarios.FechaCreacion = DateTime.Now;
            usuarios.NivelUsuario = "Administrador";
            usuarios.UsuarioId = 2;
            Assert.IsTrue(repositorioBase.Modificar(usuarios));
        }

      

        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            Assert.IsTrue(repositorioBase.Eliminar(2));
        }

       
    }
}
