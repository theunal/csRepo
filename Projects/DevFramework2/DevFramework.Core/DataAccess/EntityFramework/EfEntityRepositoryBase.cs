using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<Tentity, TContext> : IEntityRepository<Tentity>
        where Tentity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public List<Tentity> GetList(Expression<Func<Tentity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ?
                    context.Set<Tentity>().ToList() :
                    context.Set<Tentity>().Where(filter).ToList();
            }
        }
        public Tentity Get(Expression<Func<Tentity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<Tentity>().SingleOrDefault(filter);
            }
        }









        public Tentity Add(Tentity entity)
        {
            using (TContext context = new TContext())
            {
                var operation = context.Entry(entity);
                operation.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }
        public Tentity Update(Tentity entity)
        {
            using (TContext context = new TContext())
            {
                var operation = context.Entry(entity);
                operation.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
        public void Delete(Tentity entity)
        {
            using (TContext context = new TContext())
            {
                var operation = context.Entry(entity);
                operation.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }





    }
}
