using Entidades;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;

namespace TrabajoFinalRecursosHumanos.BLL
{
    public class EmpleadosBLL
    {
        public static bool Guardar(Empleados empleados)
        {
            RecursosHumanosContexto contexto = new RecursosHumanosContexto();
            bool paso = false;
            try
            {
                if(contexto.Empleados.Add(empleados)!=null)
                {
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

        public static bool Modificar(Empleados empleados)
        {
            bool paso = false;

            RepositorioBase<Contratos> repositorioBase = new RepositorioBase<Contratos>();
           
                RecursosHumanosContexto contexto = new RecursosHumanosContexto();
                try
                {
                    var contrato = repositorioBase.Buscar(empleados.ContratoId);
                    var anterior = new RepositorioBase<Empleados>().Buscar(empleados.EmpleadoId);

                    foreach (var item in anterior.Horarios)
                    {
                        if (!empleados.Horarios.Any(A => A.HorarioId == item.HorarioId))
                        {
                            contexto.Entry(item).State = EntityState.Deleted;
                        }
                    }
                    foreach (var item in empleados.Horarios)
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
                    contexto.Entry(empleados).State = EntityState.Modified;
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
            try
            {
                var Eliminar = contexto.Empleados.Find(id);
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

        public static Empleados Buscar(int id)
        {
            Empleados empleados = new Empleados();
            RecursosHumanosContexto contexto = new RecursosHumanosContexto();
            try
            {
                empleados = contexto.Empleados.Find(id);
                empleados.Horarios.Count();
            }catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return empleados;
        }

        public static List<Empleados> GetList(Expression<Func<Empleados,bool>> expression)
        {
            List<Empleados> lista = new List<Empleados>();
            RecursosHumanosContexto contexto = new RecursosHumanosContexto();
            try
            {
                lista = contexto.Empleados.Where(expression).ToList();
                
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
