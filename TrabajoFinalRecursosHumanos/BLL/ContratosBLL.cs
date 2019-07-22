using Entidades;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;

namespace TrabajoFinalRecursosHumanos.BLL
{
    public class ContratosBLL
    {
        public static bool Guardar(Contratos contratos)
        {
            RecursosHumanosContexto contexto = new RecursosHumanosContexto();
            bool paso = false;
            Empleados empleados = new Empleados();
            decimal sumando = 0;
            try
            {
                if(contexto.contratos.Add(contratos)!=null)
                {
                    foreach(var item in contratos.Horarios)
                    {
                         sumando = contexto.Empleados.Find(contratos.EmpleadoId).Salario += item.CantidadHorasExtras * item.PrecioHorasExtras;
                //        contratos.Salario = sumando;
                    }
                    paso = contexto.SaveChanges() > 0;
                }
            }catch
            {
                throw;
            }
            finally
            {
                
            }
            return paso;
        }

        public static bool Modificar(Contratos contratos)
        {
            bool paso = false;
            RecursosHumanosContexto contexto = new RecursosHumanosContexto();
            RepositorioBase<Empleados> repositorioBase = new RepositorioBase<Empleados>();
            try
            {
                var estudiante = repositorioBase.Buscar(contratos.EmpleadoId);
                var anterior = new RepositorioBase<Contratos>().Buscar(contratos.ContratoId);

                foreach (var item in anterior.Horarios)
                {
                    if (!contratos.Horarios.Any(A => A.HorarioId == item.HorarioId))
                    {
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }
                foreach (var item in contratos.Horarios)
                {
                    if (item.HorarioId == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                    }
                    else
                    {
                        contexto.Entry(item).State = EntityState.Modified;
                    }

                }
                contexto.Entry(contratos).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
    

        public static bool Eliminar(int id)
        {
            bool paso = false;
            RecursosHumanosContexto contexto = new RecursosHumanosContexto();
            decimal sumando = 0;
            try
            {                
                Contratos Eliminar = contexto.contratos.Find(id);
                foreach (var item in Eliminar.Horarios)
                {
                    sumando = contexto.Empleados.Find(Eliminar.EmpleadoId).Salario -= item.CantidadHorasExtras * item.PrecioHorasExtras;               
                }
                contexto.Entry(Eliminar).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Contratos Buscar(int id)
        {
            Contratos contratos = new Contratos();
            RecursosHumanosContexto contexto = new RecursosHumanosContexto();
            try
            {
                contratos = contexto.contratos.Find(id);
                contratos.Horarios.Count();
            }catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return contratos;
        }

        public static List<Contratos> GetList(Expression<Func<Contratos,bool>> expression)
        {
            List<Contratos> lista = new List<Contratos>();
            RecursosHumanosContexto contexto = new RecursosHumanosContexto();
            try
            {
                lista = contexto.contratos.Where(expression).ToList();
                
            }catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
