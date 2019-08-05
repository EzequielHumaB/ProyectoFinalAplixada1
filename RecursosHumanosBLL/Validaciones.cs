using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecusrosHumanosContexto;
using Entidades;

namespace RecursosHumanosBLL
{
  public class Validaciones
    {
        public static bool PalabrasNoIguales(string parametro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Usuarios.Any(p => p.Usuario.Equals(parametro)))
                {
                    paso = true;
                }
            }catch
            {
                throw;
            }
              
            return paso;
        }

     
        public static bool ContraseñasNoIguales(string contraseña)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Usuarios.Any(p => p.ConfirmarClaveUsuario.Equals(contraseña)))
                {
                    paso = true;
                }
            }catch
            {
                throw;
            }

            return paso;
        }

        public static bool CedulasNoIguales(string cedula)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Empleados.Any(p => p.Cedula.Equals(cedula)))
                {
                    paso = true;
                }
            }
            catch
            {
                throw;
            }

            return paso;
        }
       
        public static bool TelefonosNoIguales(string telefono)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Empleados.Any(p => p.Telefono.Equals(telefono)))
                {
                    paso = true;
                }
            }
            catch
            {
                throw;
            }
            return paso;
        }

        public static bool NombreDepartamentosNoIguales(string NombreDepartamento)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Departamentos.Any(p => p.NombreDepartamento.Equals(NombreDepartamento)))
                {
                    paso = true;
                }
            }
            catch
            {
                throw;
            }
            return paso;
        }

        public static bool NombresNoIguales(string descripcion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.tipoVacantes.Any(p => p.NombreTipoVacante.Equals(descripcion)))
                {
                    paso = true;
                }
            }
            catch
            {
                throw;
            }
            return paso;
        }

      

        public static bool DepartamentosNoIguales(string nombre)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Departamentos.Any(p => p.NombreDepartamento.Equals(nombre)))
                {
                    paso = true;
                }
            }catch
            {
                throw;
            }

            return paso;
        }

        public static bool VacantesNoIguales(string vacante)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if(contexto.tipoVacantes.Any(p=>p.NombreTipoVacante.Equals(vacante)))
                {
                    paso = true;
                }

            }catch
            {
                throw;
            }
            return paso;
        }
    }
}
