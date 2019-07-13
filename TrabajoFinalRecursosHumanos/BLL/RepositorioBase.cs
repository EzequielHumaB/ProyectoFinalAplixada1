using RecursosHumanosContexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinalRecursosHumanos.BLL
{
   public class RepositorioBase<T> : IDisposable,IRecursosHumanos<T> where T : class
    {
        internal RecursosHumanosContexto contexto;

        public RepositorioBase()
        {
            contexto = new RecursosHumanosContexto();
        }
        public virtual bool Guardar(T entity)
        {
            bool paso = false;
            try
            {
                if(contexto.Set<T>().Add(entity)!=null)
                {
                    paso = contexto.SaveChanges() > 0;
                }

            }catch
            {
                throw;
            }
            return paso;
        }

        public virtual bool Modificar(T entity)
        {
            bool paso = false;
            try
            {
                contexto.Entry(entity).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }catch
            {
                throw;
            }
            return paso;
        }

        public virtual bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                var eliminar = contexto.Set<T>().Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }catch
            {
                throw;
            }
            return paso;
        }

        public virtual T Buscar(int id)
        {
            T entity;
            try
            {
                entity = contexto.Set<T>().Find(id);
            }catch
            {
                throw;
            }
            return entity;
        }

        public List<T> GetList (Expression<Func<T,bool>> expression)
        {
            List<T> lista = new List<T>();
            try
            {
                lista = contexto.Set<T>().Where(expression).ToList();
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
        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
